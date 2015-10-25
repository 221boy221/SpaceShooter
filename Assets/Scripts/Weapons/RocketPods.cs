using UnityEngine;
using System.Collections;

public class RocketPods : Weapon {

	// Use this for initialization
	void Start () {
	    ammoClipMax =   10;
        ammoMax     =   50;
        damage      =   100.0f;
        cooldown    =   0.5f;
        reloadTime  =   5.0f;
        bulletSpeed =   10.0f;

        ammoInClip  = ammoClipMax;
        ammoLeft    = ammoMax;
	}

}
