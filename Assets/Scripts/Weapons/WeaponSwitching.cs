using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

    [SerializeField]
    Weapon[] _weapons;
    private int currentWeapon = 0;
    private int nrWeapons;

    void Start() {
        nrWeapons = _weapons.Length;
        SwitchWeapon(currentWeapon); // Give player the default gun to start with
    }

    void Update() {
        Inputs();
    }

    void Inputs() {
        for (int i = 0; i <= nrWeapons; i++) {
            // Keyboard number pressed
            if (Input.GetKeyDown("" + i)) {
                Debug.Log("Input: " + i);
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);
            }
        }
    }

    // Set the selected weapon to active(true) and others to active(false)
    void SwitchWeapon(int weapon) {
        Debug.Log("Switch weapon: " + weapon);
        for (int i = 0; i < nrWeapons; i++) {
            if (i == weapon) {
                _weapons[i].enabled = true;
                // TODO: Get component to get data for UI
            } else {
                _weapons[i].enabled = false;
            }
            // TODO: Update the UI (ammo count etc) when switching from weapon
        }
    }
}
