using UnityEngine;
using System.Collections;

// Boy Voesten

    //TODO:
    //  Make the ammo more standalone

// Ammunition base class
public class Ammunition : MonoBehaviour {

    private float _damage;
    private float _bulletForce;
    private Rigidbody _rbody;

	void Start () {
        _rbody = GetComponent<Rigidbody>();
        AddForce(_bulletForce);
	}

    // Default ammo behaviour
    public virtual void AddForce(float force) {
        Vector3 v3Force = force * transform.forward;
        _rbody.AddForce(v3Force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //other.GetComponent<EnemyBehaviour>().TakeDamage(_damage);
        }
    }

    // Setters
    public float bulletForce
    {
        set
        {
            _bulletForce = value;
        }
    }
    public float damage
    {
        set
        {
            _damage = value;
        }
    }
}
