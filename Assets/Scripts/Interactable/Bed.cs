using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
  
    [SerializeField] private Transform hidePoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private CharacterController playerController;

    private void Hide()
    {
        PlayerInteraction.IsPlayerHidden = true;

        PlayerMovement.IsMovementInputOn = false;
        PlayerCamera.IsCameraInputOn = false;

        playerController.enabled = false;
        playerController.transform.position = hidePoint.position;
        playerController.transform.rotation = hidePoint.localRotation;
        playerController.enabled = true;
    }

    private void Exit()
    {
        PlayerInteraction.IsPlayerHidden = false;

        PlayerMovement.IsMovementInputOn = true;
        PlayerCamera.IsCameraInputOn = true;

        playerController.enabled = false;
        playerController.transform.position = exitPoint.position;
        playerController.transform.rotation = exitPoint.localRotation;
        playerController.enabled = true;
    }

    private void Update()
    {
        if (PlayerInteraction.IsPlayerHidden && Input.GetButtonDown("Fire1"))
        {
            Exit();
        }
    }
    public void Interact(PlayerInventory playerInventory)
    {
        if (!PlayerInteraction.IsPlayerHidden)
        {
             Hide();
        }
    }
}


