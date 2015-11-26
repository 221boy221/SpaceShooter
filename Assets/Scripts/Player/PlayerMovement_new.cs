using UnityEngine;
using System.Collections;

// Boy Voesten

public class PlayerMovement_new : MonoBehaviour {

    private bool _isWalking;
    private bool _toggleMove;
    private Vector3 _moveDirection;

    private float _speedMod = 1.0f;
    private float _walkBackMod = 0.5f;
    private float _strafeWalkMod = 0.7f;
    private float _walkSpeed;
    private float _sprintSpeed;
    private float _rotateSpeed;

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

        // If strafing and moving forward at the same time, apply _strafeWalkMod
        if (Input.GetAxis("Strafing") != 0 && Input.GetAxis("Horizontal") != 0) {
            _moveDirection *= _strafeWalkMod;
        }

        // If moving backwards, apply _walkBackMod
        if ((Input.GetAxis("Vertical") < 0 || Input.GetAxis("Strafing") != 0 && Input.GetAxis("Horizontal") != 0) {
            _speedMod = _walkBackMod;
        } else {
            _speedMod = 1.0f;
        }

        // Apply walking/sprinting speed
        if (_isWalking) {
            _moveDirection *= _walkSpeed * _speedMod;
        } else {
            _moveDirection *= _sprintSpeed * _speedMod;
        }

        _moveDirection = transform.TransformDirection(_moveDirection);
        // TODO

        // Makes it so that you can look around your ship
        if (Input.GetMouseButton(1)) {
            transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
        } else {
            transform.Rotate(0, Input.GetAxis("Horizontal") * _rotateSpeed * Time.deltaTime, 0);
        }
    }
}
