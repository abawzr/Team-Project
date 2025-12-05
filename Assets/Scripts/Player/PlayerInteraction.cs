using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float interactionRayDistance;
    [SerializeField] private LayerMask interacitonLayer;
    [SerializeField] private PlayerInventory playerInventory;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mainCamera.position, mainCamera.forward * interactionRayDistance);
    }

    private void Update()
    {
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hitInfo, interactionRayDistance, interacitonLayer))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(playerInventory);
                }
            }
        }
    }
}
