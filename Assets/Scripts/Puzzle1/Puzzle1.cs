using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    [SerializeField] private Puzzle1Slot[] slots;
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
                return; // At least one slot is wrong
            }
        }

        // All slots correct, puzzle solved
        IsSolved = true;

        foreach (Puzzle1Slot slot in slots)
        {
            Destroy(slot);
        }

        MainDoor.IsPuzzle1Solved = true;
        mainDoorAudioSource.PlayOneShot(mainDoorUnlockClip);

        if (MainDoor.IsPuzzle1Solved && MainDoor.IsPuzzle2Solved)
        {
            mainDoorTextAnimator.SetTrigger("Unlock");
        }
    }
}
