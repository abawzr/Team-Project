using UnityEngine;

public class BodyPuzzle : MonoBehaviour
{
    [SerializeField] private BodySlot[] slots;
    [SerializeField] private AudioSource mainDoorAudioSource;
    [SerializeField] private AudioClip mainDoorUnlockClip;
    [SerializeField] private Animator mainDoorTextAnimator;

    public bool IsSolved { get; private set; }

    public void CheckSolution()
    {
        if (IsSolved) return;

        foreach (var slot in slots)
        {
            if (!slot.IsCorrect())
            {
                return;
            }
        }

        IsSolved = true;
        MainDoor.puzzle2Done = true;
        mainDoorAudioSource.PlayOneShot(mainDoorUnlockClip);

        if (MainDoor.puzzle1Done && MainDoor.puzzle2Done)
        {
            mainDoorTextAnimator.SetTrigger("Unlock");
        }
    }
}
