using UnityEngine;
using System.Collections;

// Boy Voesten

// Weapon base class
public class Weapon : MonoBehaviour {
    
    [SerializeField]
    private GameObject ammunition;

    protected int ammoClipMax;
    protected int ammoMax;
    protected int ammoInClip;
    protected int ammoLeft;
    protected float damage;
    protected float cooldown;
    protected float reloadTime;
    protected float bulletSpeed;
    
    private float _nextFireTime;
    private bool _reloading;
    

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
        Debug.Log("Done");
    }

    void Shoot() {
        Debug.Log("Shoot");
        _nextFireTime = Time.time + cooldown;
        ammoInClip--;
        GameObject tempObj = (GameObject)Instantiate(ammunition, transform.position, transform.rotation);
        tempObj.transform.forward = transform.forward;
        tempObj.GetComponent<Ammunition>().bulletForce = bulletSpeed;
        //var rotation = Quternion.FromToRotation(bulletPrefab.forward, Spawn.position.forward); var instanceBullet = Instantiate(bulletPrefab, Spawn.position, rotation);
    }
}
