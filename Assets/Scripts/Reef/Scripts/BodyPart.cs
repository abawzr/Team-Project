using UnityEngine;

public class BodyPart : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite itemIcon;

    public int weight;

    public void Interact(PlayerInventory playerInventory)
    {
        playerInventory.PickItem(gameObject, itemIcon);
    }
}
