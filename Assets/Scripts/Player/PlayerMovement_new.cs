using UnityEngine;
using System.Collections;

// Boy Voesten

public class PlayerMovement_new : MonoBehaviour {

    private bool _isWalking;
    private bool _toggleMove;
    private Vector3 _moveDirection;

    private float _speedMod = 1.0f;
    private float _walkBackMod = 0.5f;
    

    void Update() {
        
        // Hold 'Shift' to Sprint
        if (Input.GetAxis("Sprint") != 0) {
            _isWalking = false;
        } else {
            // Default movement, calling it Walking just to better understand
            _isWalking = true;
        }
    }

    void Movement() {
        // If Mouse button 1 is pressed, getAxis Horizontal, otherwise 0;
        _moveDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));

        // Both mouse buttons or ToggleMove
        if(Input.GetMouseButton(0) && Input.GetMouseButton(1) || _toggleMove) {
            // Move Forward
            _moveDirection.z += 1;
        }

        if (_moveDirection.z > 1) {
            _moveDirection.z = 1;
        }

        // Side-Strafing
        _moveDirection.x -= Input.GetAxis("Strafing");

        // If strafing and moving forward at the same time
        if(Input.GetAxis("Strafing") != 0 && Input.GetAxis("Horizontal") != 0) {
            _moveDirection *= 0.7f;
        }

        // If moving backwards, apply walkBackMod
        if ((Input.GetAxis("Vertical") < 0 || Input.GetAxis("Strafing") != 0 && Input.GetAxis("Horizontal") != 0) {
            _speedMod = _walkBackMod;
        } else {
            _speedMod = 1.0f;
        }

        // TODO

    }
}
