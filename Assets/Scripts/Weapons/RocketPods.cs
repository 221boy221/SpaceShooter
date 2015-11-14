using UnityEngine;
using System.Collections;

// Boy Voesten

public class RocketPods : Weapon {

    [SerializeField]
    GameObject ammunition;

	void Start() {
	    ammoClipMax = 10;
        ammoMax     = 50;
        damage      = 50.0f;
        cooldown    = 0.5f;
        reloadTime  = 5.0f;
        bulletSpeed = 10.0f;
        range       = 200.0f;

        ammoInClip = ammoClipMax;
        ammoLeft = ammoMax;
        gunAudio.clip = shootAudioClip;
	}

    public override void Shoot() {
        base.Shoot();
        
        // Projectile
        GameObject tempObj = (GameObject)Instantiate(ammunition, transform.position, transform.rotation);
        tempObj.transform.rotation = transform.parent.rotation;
        Ammunition tempObjAmmo = tempObj.GetComponent<Ammunition>();
        //tempObj.GetComponent<Rigidbody>().velocity = GetComponentInParent<Rigidbody>().velocity;
        tempObjAmmo.damage = damage;
        tempObjAmmo.AddForce(bulletSpeed);
    }

}
