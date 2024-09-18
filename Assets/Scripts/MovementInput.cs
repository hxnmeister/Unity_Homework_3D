using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class MovementInput : MonoBehaviour
{
    [SerializeField]
    private float currentSpeed;

    [SerializeField]
    private float boostingSpeed;

    [SerializeField]
    private float normalSpeed = 20.0F;

    [SerializeField]
    private float gravity = -9.8F;

    [SerializeField]
    private float jumpForce = 5.0F;

    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();

        boostingSpeed = normalSpeed * 2.0F;
        currentSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = boostingSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = normalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.01F)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float horizontal = Input.GetAxis("Horizontal") * currentSpeed;
        float vertical = Input.GetAxis("Vertical") * currentSpeed;
        Vector3 movement = new (horizontal, gravity, vertical);

        movement = Vector3.ClampMagnitude(movement, currentSpeed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _characterController.Move(movement);
    }
}
