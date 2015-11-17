using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class PlayerShip : MonoBehaviour {

    private float _score;
    private float _health = 100f;
    private float _damageScale = 10f;
    private Rigidbody _rbody;

    // Use this for initialization
    void Start () {
        _rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision target) {
        if (target.collider.tag == "Asteroid") {
            Debug.Log("Collision with Asteroid");
            TakeDamage(CalcDamage(target.gameObject));
        } else {
            Debug.Log("Nope");
        }
    }

    private float CalcDamage(GameObject target) {
        return Mathf.Round((target.GetComponent<Rigidbody>().velocity - _rbody.velocity).magnitude * _damageScale);
    }

    private void TakeDamage(float dmg) {
        Debug.Log("TakeDamage: " + dmg);
        if(_health - dmg <= 0) {
            Dead();
        } else {
            _health -= dmg;
        }
    }

    private void Dead() {
        //Destroy(gameObject);
        Debug.Log("Dead");
    }
}
