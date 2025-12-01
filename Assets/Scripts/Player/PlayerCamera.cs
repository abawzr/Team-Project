using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float sensitivity;

    private float _mouseX;
    private float _mouseY;
    private float _xRotation;

    private void LateUpdate()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivity;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        mainCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(transform.up * _mouseX);
    }
}
