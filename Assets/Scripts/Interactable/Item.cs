using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInventory playerInventory)
    {
        playerInventory.PickItem(gameObject);
    }
}
