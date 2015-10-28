using UnityEngine;
using System.Collections;

// Boy Voesten

//TODO:
//  Add cluster (Obj breaking in two upon destroyed)

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField] private float _health;
    //[SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _hasClusters = false;
    [SerializeField] private float forceToAdd = 2.0f;
    private Rigidbody _rbody;
    private Transform _transform;

    void Start() {
        _rbody = GetComponent<Rigidbody>();
        _transform = transform;
        _rbody.velocity = Random.insideUnitSphere * forceToAdd;
    }

    public void TakeDamage(float dmg) {
        if (_health - dmg <= 0) {
            Explode();
        } else {
            _health -= dmg;
        }
    }

    void Explode() {
        if (!_hasClusters) {
            Destroy(gameObject);
        } else {
            GetComponent<AsteroidCluster>().Cluster();
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
            Vector3 newHitForce = (_transform.position - other.contacts[0].point).normalized * forceToAdd;

            //Debug.Log("World hit point = " + other.contacts[0].point + " : Local hit point = " + localHitPoint + " : new Hit Force = " + newHitForce);

            _rbody.AddForceAtPosition(newHitForce, localHitPoint, ForceMode.Impulse);
        }
        
    }*/

}
