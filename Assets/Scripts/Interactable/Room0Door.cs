using UnityEngine;

public class Room0Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hammer;

    public void Interact(PlayerInventory playerInventory)
    {
        if (playerInventory.CurrentItem == hammer)
        {
            playerInventory.UseItem();
            transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        }
        
    }
}
