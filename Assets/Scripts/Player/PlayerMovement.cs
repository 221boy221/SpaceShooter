using UnityEngine;
using System.Collections;

// Boy Voesten

public class PlayerMovement : MonoBehaviour {

    float _mouseSensitivity = 1.0f;
    float _movementSpeed = 300.0f;
    float _rotationSpeed = 10.0f;
    Rigidbody _rigidbody;
    
    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _mouseSensitivity = GameObject.FindGameObjectWithTag(TagList.Settings).GetComponent<Settings>().mouseSens;

        //Screen.lockCursor = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update() {
        MouseRotation();
        Movement();
    }

    void MouseRotation() {
        float horizontalRot = 0;
        float verticleRot = 0;
        horizontalRot = Input.GetAxisRaw("Mouse X") * _mouseSensitivity;
        verticleRot -= Input.GetAxisRaw("Mouse Y") * (_mouseSensitivity / 2);

        transform.Rotate(verticleRot, horizontalRot, 0);
    }

    void Movement() {
        _rigidbody.AddForce(Input.GetAxis("Vertical")       * transform.forward * Time.deltaTime * _movementSpeed);
        _rigidbody.AddForce(Input.GetAxis("Horizontal")     * transform.right   * Time.deltaTime * _movementSpeed);
        _rigidbody.AddForce(Input.GetAxis("Up/Down")        * transform.up      * Time.deltaTime * _movementSpeed);
        _rigidbody.AddForce(Input.GetAxis("Speedboost")     * transform.forward * Time.deltaTime * (_movementSpeed * 2));
        _rigidbody.AddTorque(Input.GetAxis("Rotation")      * transform.forward * Time.deltaTime * _rotationSpeed);

        //Brake
        if (Input.GetKey(KeyCode.LeftControl)) {
            _rigidbody.velocity = _rigidbody.velocity * 0.95f;
            _rigidbody.angularVelocity = _rigidbody.angularVelocity * 0.95f;
        }
    }
}
