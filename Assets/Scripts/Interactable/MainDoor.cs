using UnityEngine;

public class MainDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Ending ending;

    public static bool Lock1 { get; set; } = true;
    public static bool Lock2 { get; set; } = true;

    public void Interact(PlayerInventory playerInventory)
    {
        if (!Lock1 && !Lock2)
        {
            ending.TriggerEnding1();
        }
    }
}
