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
    private float normalSpeed = 5.0F;

    [SerializeField]
    private float gravity = -9.8F;

    [SerializeField]
    private float jumpForce = 5.0F;

    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();

        boostingSpeed = normalSpeed * 2.0F;
        currentSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving = horizontal != 0 || vertical != 0;
        

        if (isMoving)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = boostingSpeed;
                _animator.SetBool("isRunning", true);
            }
            else
            {
                currentSpeed = normalSpeed;
                _animator.SetBool("isRunning", false);
                _animator.SetBool("isWalking", true);
            }
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        Vector3 movement = new(horizontal * currentSpeed, gravity, vertical * currentSpeed);

        movement = Vector3.ClampMagnitude(movement, currentSpeed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _characterController.Move(movement);

        if (!isMoving)
        {
            _animator.SetBool("isIdle", true);
        }
        else
        {
            _animator.SetBool("isIdle", false);
        }
    }
}
