using UnityEngine;

public class MainDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Ending ending;
    [SerializeField] private AudioSource mainDoorAudioSource;
    [SerializeField] private AudioClip mainDoorLockedClip;

    public static bool IsPuzzle1Solved { get; set; } = false;
    public static bool IsPuzzle2Solved { get; set; } = false;

    public void Interact(PlayerInventory playerInventory)
    {
        if (IsPuzzle1Solved && IsPuzzle2Solved)
        {
            ending.TriggerEnding1();
        }

        else
        {
            mainDoorAudioSource.PlayOneShot(mainDoorLockedClip);
        }
    }
}
