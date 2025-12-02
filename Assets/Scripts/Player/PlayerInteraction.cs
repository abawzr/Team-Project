using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float interactionRayDistance;
    [SerializeField] private LayerMask interacitonLayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mainCamera.position, mainCamera.forward * interactionRayDistance);
    }

    private void Update()
    {
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, interactionRayDistance, interacitonLayer))
        {
        }
    }
}
