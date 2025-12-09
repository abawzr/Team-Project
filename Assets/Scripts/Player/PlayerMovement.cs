using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravity;
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float walkStepInterval;
    [SerializeField] private float runStepInterval;

    private CharacterController _controller;
    private Vector3 _movementDirection;
    private float _inputX;
    private float _inputY;
    private bool _canDoubleJump;
    private bool _isCrouch;
    private float _verticalVelocity;
    private float _stepTimer;

    public static bool IsMovementInputOn { get; set; }

    //hiding
   //  public bool isHiding=false;

    private void Awake()
    {
        // Get Character Controller component from same game object this script attached to
        _controller = GetComponent<CharacterController>();
        IsMovementInputOn = true;
    }

    private void Update()
    {
        //hiding 
        //if (isHiding)
        //    return;


        // Apply gravity method
        ApplyGravity();

        if (IsMovementInputOn)
        {
            // Get horizontal input = A/D and vertical input = W/S
            _inputX = Input.GetAxisRaw("Horizontal");
            _inputY = Input.GetAxisRaw("Vertical");

            // Check if player is grounded, then assign true to canDoubleJump variable
            if (_controller.isGrounded)
            {
                _canDoubleJump = true;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = 7;
                // footstepInterval = ;
            }
            else
            {
                movementSpeed = 3;
                // footstepInterval = ;
            }

            Jump();

            CalculateMovement();

            PlayFootstep();
        }
    }

    private void CalculateMovement()
    {
        // Get the X axis of player and multiply by inputX (A/D) and add it to the Z axis of player and multiply by inputY (W/S),
        //  then normalize the vector to make magnitude always 1 instead of 1.43 when moving diagnolly
        //  then multiply by movementSpeed
        _movementDirection = (transform.right * _inputX + transform.forward * _inputY).normalized * movementSpeed;

        // Set the Y axis of movementDirection vector to verticalVelocity variable
        _movementDirection.y = _verticalVelocity;

        // Use Move method from Character Controller and pass movementDirection multiply by Time.deltaTime to make movement frame-rate independent
        _controller.Move(_movementDirection * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        // If player is grounded, then set veticalVelocity variable to -2f
        if (_controller.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f;
        }

        // Else multiply gravity by Time.deltaTime then add it to verticalVeloctiy variable
        else
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        // First Jump
        // Check if player pressed jump button and player is grounded and is not crouched, then assign jumpPower to verticalVelocity variable
        if (Input.GetButtonDown("Jump") && _controller.isGrounded && !_isCrouch)
        {
            _verticalVelocity = jumpPower;
        }

        // Double Jump
        // Check if player pressed jump button and player is not grounded and can double jump and is not crouched,
        //  then assign jumpPower to verticalVelocity variable, assign false to canDoubleJump variable
        //  limit the player from jumping twice
        else if (Input.GetButtonDown("Jump") && !_controller.isGrounded && _canDoubleJump && !_isCrouch)
        {
            _verticalVelocity = jumpPower;
            _canDoubleJump = false;
        }
    }

    private void PlayFootstep()
    {
        if (footstepClip == null) return;

        // Player is not moving
        if (new Vector2(_inputX, _inputY) == Vector2.zero || !_controller.isGrounded)
        {
            _stepTimer = 0;
            return;
        }

        float stepInterval = movementSpeed < 5 ? walkStepInterval : runStepInterval;

        _stepTimer += Time.deltaTime;

        if (_stepTimer >= stepInterval)
        {
            footstepAudioSource.PlayOneShot(footstepClip);
            _stepTimer = 0;
        }
    }
}
