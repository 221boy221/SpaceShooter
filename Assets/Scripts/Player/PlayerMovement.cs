using UnityEngine;
using System.Collections;

// Boy Voesten

public class PlayerMovement : MonoBehaviour
{
    float _mouseSensitivity;
    float _verticleMouseRange = 60.0f;
    float _maxSpeed = 10.0f;
    [SerializeField] float _movementSpeed = 100.0f;
    [SerializeField] float _rotationSpeed = 50.0f;
    Vector2 _velocity = new Vector2(0,0);
    Rigidbody _rigidbody;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mouseSensitivity = GameObject.FindGameObjectWithTag(TagList.Settings).GetComponent<Settings>().mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Movement();
    }

    void Rotation()
    {
        Debug.Log("Rot");
        float horizontalRot = 0;
        float verticleRot = 0;
        Debug.Log(horizontalRot);
        Debug.Log(verticleRot);
        horizontalRot = Input.GetAxisRaw("Mouse X") * _mouseSensitivity;
        verticleRot -= Input.GetAxisRaw("Mouse Y") * (_mouseSensitivity / 2);

        transform.Rotate(verticleRot, horizontalRot, 0);
        //Camera.main.transform.localRotation = Quaternion.Euler(verticleRot, 0, 0);
    }

    void Movement()
    {
        //Debug.Log("Velocity: " + _rigidbody.velocity);
        _rigidbody.AddForce(Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * _movementSpeed);
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * _movementSpeed);
        _rigidbody.AddTorque(transform.forward * Input.GetAxis("Rotation") * Time.deltaTime * _rotationSpeed);
    }
}
