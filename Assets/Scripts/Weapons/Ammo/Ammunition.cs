﻿using UnityEngine;
using System.Collections;

// Boy Voesten

// Ammunition base class
public class Ammunition : MonoBehaviour {

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

    //Setter
    public float bulletForce {
        set {
            _bulletForce = value;
        }
    }
}
