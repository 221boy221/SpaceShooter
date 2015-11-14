﻿using UnityEngine;
using System.Collections;

// Boy Voesten

public class Turret : Weapon {

    void Start() {
        ammoClipMax = 50;
        ammoMax     = 500;
        damage      = 10.0f;
        cooldown    = 0.1f;
        reloadTime  = 5.0f;
        bulletSpeed = 25.0f;
        range       = 100.0f;

        ammoInClip = ammoClipMax;
        ammoLeft = ammoMax;
    }

    public override void Shoot() {
        base.Shoot();

        // Ray
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out rayHit, range, shootableMask)) {
            AsteroidBehaviour asteroid = rayHit.collider.GetComponent<AsteroidBehaviour>();
            if (asteroid != null) {
                asteroid.HitEffect(rayHit.point);
                asteroid.TakeDamage(damage);
            }
            gunLine.SetPosition(1, rayHit.point);
        } else {
            gunLine.SetPosition(1, ray.origin + ray.direction * range);
        }
    }
}
