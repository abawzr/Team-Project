using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetFPS;

    private void Start()
    {
        // Hide the cursor in-game
        Cursor.lockState = CursorLockMode.Locked;

        // Lock maximum frame rate to targetFPS
        Application.targetFrameRate = targetFPS;
    }
}
