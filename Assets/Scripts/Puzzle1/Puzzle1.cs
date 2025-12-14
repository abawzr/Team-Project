using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // [SerializeField] private MainDoor mainDoor;
    [SerializeField] private Puzzle1Slot[] slots;
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

        Debug.Log("Puzzle 1 Solved");
        MainDoor.Lock1 = false;
    }
}
