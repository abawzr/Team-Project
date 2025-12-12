using UnityEngine;

public class Room0Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hammer;

    public static bool IsSolved = false;

    public void Interact(PlayerInventory playerInventory)
    {
        if (playerInventory.CurrentItem == hammer)
        {
            playerInventory.UseItem();
            transform.localRotation = Quaternion.Euler(0f, -122f, 0f);
            IsSolved = true;
            Destroy(this);
        }
        
    }
}
