using UnityEngine;
using System.Collections;

// Boy Voesten

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField] private float _startHealth;
    [SerializeField] private bool _hasClusters = false;
    [SerializeField] private float _forceToAdd = 2.0f;
    [SerializeField] private AudioSource _asteroidAudio;
    [SerializeField] private AudioClip _deadAudio;
    private float _health;
    private ParticleSystem _hitParticles;
    private Rigidbody _rbody;

    void Awake() {
        _asteroidAudio = GetComponent<AudioSource>();
        _hitParticles = GetComponentInChildren<ParticleSystem>();
        _health = _startHealth;
    }

    void Start() {
        _rbody = GetComponent<Rigidbody>();
        _rbody.velocity = Random.insideUnitSphere * _forceToAdd;
    }

    public void HitEffect(Vector3 hitPoint) {
        // Hit Effect
        
        _hitParticles.transform.position = hitPoint;
        _hitParticles.Play();
    }

    public void TakeDamage(float dmg) {
        // Take damage
        _asteroidAudio.Play();

        Debug.Log("Taking " + dmg + " damage");

        if (_health - dmg <= 0) {
            Explode();
        } else {
            _health -= dmg;
        }
    }

    void Explode() {
        Debug.Log("Explode");
        if (!_hasClusters) {
            Destroy(gameObject);
        } else {
            GetComponent<AsteroidCluster>().Cluster();
            Destroy(gameObject);
        }
    }

    /* 
    void OnCollisionEnter(Collision other) {
       
        if (other.collider.gameObject.tag == "Asteroid") {
            Vector3 normal = other.transform.right;
            Vector3 dir = transform.right;
            Vector3.Reflect(dir, normal);
        } else {
            Vector3 localHitPoint = other.contacts[0].point - _transform.position;
            Vector3 newHitForce = (_transform.position - other.contacts[0].point).normalized * _forceToAdd;

            //Debug.Log("World hit point = " + other.contacts[0].point + " : Local hit point = " + localHitPoint + " : new Hit Force = " + newHitForce);

            _rbody.AddForceAtPosition(newHitForce, localHitPoint, ForceMode.Impulse);
        }
    }*/

}
