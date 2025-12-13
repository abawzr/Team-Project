using UnityEngine;

public class MainDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Ending ending;

    public void Interact(PlayerInventory playerInventory)
    {
        ending.TriggerEnding1();
    }
}
