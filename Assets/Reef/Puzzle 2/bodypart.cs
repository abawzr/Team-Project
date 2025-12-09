using UnityEngine;

public class bodypart : MonoBehaviour, IInteractable
{
    public int partID;
    [SerializeField] private Sprite itemIcon;


    public void Interact(PlayerInventory playerInventory)
    {
        Debug.Log("dasd");
        playerInventory.PickItem(gameObject, itemIcon);
    }
}
