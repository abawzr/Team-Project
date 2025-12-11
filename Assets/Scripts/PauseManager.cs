using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;

    void Start()
    {
        // Make sure the pause menu is hidden at start
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // Check if ESC or P key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // This freezes the game
        isPaused = true;
        
        // Show and unlock cursor for menu interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // This resumes normal game speed
        isPaused = false;
        
        // Hide and lock cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale before loading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale before loading
        SceneManager.LoadScene("main menu"); // Replace with your main menu scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        // This only works in a built game, not in the Unity Editor
    }
}