using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite itemIcon;

    public void Interact(PlayerInventory playerInventory)
    {
        playerInventory.PickItem(gameObject, itemIcon);
    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }
}
