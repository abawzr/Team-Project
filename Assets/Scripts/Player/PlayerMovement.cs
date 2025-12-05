using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravity;
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float footstepInterval;

    private CharacterController _controller;
    private Vector3 _movementDirection;
    private float _inputX;
    private float _inputY;
    private bool _canDoubleJump;
    private bool _isCrouch;
    private float _verticalVelocity;

    public static bool IsMovementInputOn { get; set; }

    private void Awake()
    {
        // Get Character Controller component from same game object this script attached to
        _controller = GetComponent<CharacterController>();
        IsMovementInputOn = true;
    }

    private void Start()
    {
        StartCoroutine(PlayFootstep());
    }

    private void Update()
    {
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

            Jump();

            Crouch();

            CalculateMovement();
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

    private void Crouch()
    {
        // Check if player pressed C key and the scale of y is equal to 1 and player is grounded, 
        //  then set the scale of y to 0.5f, and set isCrouch variable to true 
        if (Input.GetKeyDown(KeyCode.C) && transform.localScale.y == 1f && _controller.isGrounded)
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
            _isCrouch = true;
            movementSpeed -= 2f;
        }

        // Check if player pressed C key and the scale of y is equal to 0.5, 
        //  then set the scale of y to 1f, and set isCrouch variable to false
        else if (Input.GetKeyDown(KeyCode.C) && transform.localScale.y == 0.5f)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
            _isCrouch = false;
            movementSpeed += 2f;
        }
    }

    private IEnumerator PlayFootstep()
    {
        while (true)
        {
            if (new Vector2(_inputX, _inputY) != Vector2.zero && _controller.isGrounded)
            {
                footstepAudioSource.PlayOneShot(footstepClip);
                yield return new WaitForSeconds(footstepInterval);
            }

            yield return null;
        }
    }
}
