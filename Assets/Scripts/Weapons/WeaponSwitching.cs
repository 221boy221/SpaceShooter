using UnityEngine;
using System.Collections;

// Boy Voesten

public class WeaponSwitching : MonoBehaviour {

    [SerializeField]
    Weapon[] _weapons;
    private int currentWeapon = 0;
    private int nrWeapons;

    void Start() {
        nrWeapons = _weapons.Length;
        SwitchWeapon(0); // Give player the default gun to start with
    }

    void Update() {
        Inputs();
    }

    void Inputs() {
        for (int i = 0; i <= nrWeapons; i++) {
            // Keyboard number pressed
            if (Input.GetKeyDown((i+1).ToString())) {
                Debug.Log("Input: " + (i+1) + " | Weapon NR: " + i);
                SwitchWeapon(i);
            }
        }
    }

    // Switch weapon for another
    void SwitchWeapon(int weapon) {
        // Disable current weapon
        if (currentWeapon >= 0 && currentWeapon < nrWeapons) {
            _weapons[currentWeapon].enabled = false;
        }

        // Enable new weapon
        if (weapon >= 0 && weapon < nrWeapons) {
            _weapons[weapon].enabled = true;
            _weapons[weapon].SwitchAudio();
            currentWeapon = weapon;
        }
        // TODO: Update the UI (ammo count etc) when switching from weapon
    }
}
