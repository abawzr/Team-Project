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
        MainDoor.IsPuzzle2Solved = true;
        mainDoorAudioSource.PlayOneShot(mainDoorUnlockClip);

        if (MainDoor.IsPuzzle1Solved && MainDoor.IsPuzzle2Solved)
        {
            mainDoorTextAnimator.SetTrigger("Unlock");
        }
    }
}
