using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator doorAnim;

    public static bool puzzle1Done = false;
    public static bool puzzle2Done = false;

    public void OpenIfSolved()
    {
        if (puzzle1Done && puzzle2Done)
        {
            doorAnim.SetTrigger("Open");
        }
        else
        {
            Debug.Log("Door locked. Puzzles not solved yet.");
        }
    }
}
