using UnityEngine;
using System.Collections;

// Boy Voesten

//TODO:
//  Make the ammo more standalone

// Ammunition base class
public class Ammunition : MonoBehaviour {

    private float _damage;
    private Rigidbody _rbody;

    // Default ammo behaviour
    public virtual void AddForce(float force) {
        _rbody = GetComponent<Rigidbody>();
        Vector3 v3Force = force * transform.forward;
        _rbody.AddForce(v3Force, ForceMode.Impulse);
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Asteroid") {
            other.GetComponent<AsteroidBehaviour>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
    
    // Setters
    public float damage {
        set {
            _damage = value;
        }
    }
}
