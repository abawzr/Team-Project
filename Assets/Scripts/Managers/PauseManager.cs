using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    private bool _isPaused = false;

    private void Start()
    {
        // Make sure the pause menu is hidden at start
        pauseMenuPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if ESC or P key is pressed
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !PlayerInteraction.IsPlayerReading)
        {
            if (_isPaused)
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
        _isPaused = true;

        // Show and unlock cursor for menu interaction
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        PlayerCamera.IsCameraInputOn = false;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // This resumes normal game speed
        _isPaused = false;

        // Hide and lock cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerCamera.IsCameraInputOn = true;
    }

    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale before loading
        SceneManager.LoadSceneAsync("MainMenuScene"); // Replace with your main menu scene name
    }
}