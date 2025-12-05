using UnityEngine;

public class Locker : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform hidePoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private CharacterController playerController;

    private bool _isPlayerHidden;

    private void Hide()
    {
        _isPlayerHidden = true;

        PlayerMovement.IsMovementInputOn = false;
        PlayerCamera.IsCameraInputOn = false;

        playerController.enabled = false;
        playerController.transform.position = hidePoint.position;
        playerController.transform.rotation = hidePoint.localRotation;
        playerController.enabled = true;
    }

    private void Exit()
    {
        _isPlayerHidden = false;

        PlayerMovement.IsMovementInputOn = true;
        PlayerCamera.IsCameraInputOn = true;

        playerController.enabled = false;
        playerController.transform.position = exitPoint.position;
        playerController.transform.rotation = exitPoint.localRotation;
        playerController.enabled = true;
    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (_isPlayerHidden)
        {
            Exit();
        }

        else
        {
            Hide();
        }
    }
}
