using UnityEngine;

public class MainDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Ending ending;
    [SerializeField] private AudioSource mainDoorAudioSource;
    [SerializeField] private AudioClip mainDoorLockedClip;

    public static bool puzzle1Done = false;
    public static bool puzzle2Done = false;

    public void Interact(PlayerInventory playerInventory)
    {
        if (puzzle1Done && puzzle2Done)
        {
            ending.TriggerEnding1();
        }
        else
        {
            mainDoorAudioSource.PlayOneShot(mainDoorLockedClip);
        }
    }
}
