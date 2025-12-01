using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravity;

    private CharacterController _controller;
    private Vector3 _movementDirection;
    private float _inputX;
    private float _inputY;
    private bool _canDoubleJump;
    private float _verticalVelocity = -2f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();

        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
            _canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            _verticalVelocity = jumpPower;
        }

        if (Input.GetButtonDown("Jump") && !_controller.isGrounded && _canDoubleJump)
        {
            _verticalVelocity = jumpPower;
            _canDoubleJump = false;
        }

        _movementDirection = (transform.right * _inputX + transform.forward * _inputY) * movementSpeed;
        _movementDirection.y = _verticalVelocity;

        _controller.Move(_movementDirection * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity = -2f;
        }

        else
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
