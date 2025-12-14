using UnityEngine;

public class BodyPuzzle : MonoBehaviour
{
    [SerializeField] private BodySlot[] slots;

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
        MainDoor.Lock2 = false;
    }
}
