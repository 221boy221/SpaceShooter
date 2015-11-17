using UnityEngine;
using System.Collections;

// Boy Voesten

// Weapon base class
[RequireComponent(typeof(AudioSource), typeof(Light), typeof(ParticleSystem))]
[RequireComponent(typeof(LineRenderer))]
public class Weapon : MonoBehaviour {
    
    protected int ammoClipMax;
    protected int ammoMax;
    protected int ammoInClip;
    protected int ammoLeft;
    protected float damage;
    protected float cooldown;
    protected float reloadTime;
    protected float bulletSpeed;
    protected float range;
    protected int shootableMask;
    protected Ray ray;
    protected RaycastHit rayHit;
    protected ParticleSystem gunParticles;
    protected LineRenderer gunLine;
    protected Light gunLight;
    [SerializeField] protected AudioClip shootAudioClip;
    protected float pitchMin;
    protected float pitchMax;
    private float _nextFireTime;
    private float _fxTime = 0.05f;
    private bool _reloading;
    private AudioSource _gunAudio;

    void Awake() {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        _gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

	void Update () {
        Inputs();
	}

    void Inputs() {
        if (Input.GetKey(KeyCode.Escape)) {
            Debug.Log("ammoClipMax: " + ammoClipMax);
            Debug.Log("ammoMax: " + ammoMax);
            Debug.Log("damage: " + damage);
            Debug.Log("cooldown: " + cooldown);
            Debug.Log("reloadTime: " + reloadTime);
            Debug.Log("_nextFireTime: " + _nextFireTime);
            Debug.Log("_reloading: " + _reloading);
            Debug.Log("ammoInClip: " + ammoInClip);
            Debug.Log("ammoLeft: " + ammoLeft);
        }
        if (Input.GetMouseButton(0) && Time.time > _nextFireTime) {
            if (ammoInClip > 0) {
                Shoot();
            } else if (ammoInClip <= 0 && !_reloading) {
                StartCoroutine("Reload");
            }
        }
        if (Input.GetKey(KeyCode.R) && ammoInClip < ammoClipMax && !_reloading) {
            StartCoroutine("Reload");
        }
    }

    // We use an IEnumerator so we can easily use the WaitForSeconds for the reloadTime
    IEnumerator Reload() {
        Debug.Log("Reloading...");
        _reloading = true;
        yield return new WaitForSeconds(reloadTime);
        if ((ammoLeft -= (ammoClipMax - ammoInClip)) < 0) {
            ammoInClip += ammoLeft;
            ammoLeft = 0;
        } else {
            ammoLeft -= (ammoClipMax - ammoInClip);
            ammoInClip = ammoClipMax;
        }
        _reloading = false;
        Debug.Log("Done Reloading");
    }
    
    void DisableFX() {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public virtual void Shoot() {
        _nextFireTime = Time.time + cooldown;
        ammoInClip--;

        Invoke("DisableFX", _fxTime);
        _gunAudio.pitch = Random.Range(pitchMin, pitchMax);
        _gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();
    }

    public virtual void SwitchAudio() {
        Debug.Log("_gunAudio.clip = " + shootAudioClip.name);
        _gunAudio.clip = shootAudioClip;
        
    }

}
