using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;
    
    [Header("Main Menu Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;
    
    [Header("Settings Menu")]
    public Button backButton;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;
    
    [Header("Scene Settings")]
    public string gameSceneName = "GameScene"; // Name of your game scene
    
    void Start()
    {
        // Show main menu, hide settings
        ShowMainMenu();
        
        // Load saved volume settings
        LoadVolumeSettings();
        
        // Setup button listeners
        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
        backButton.onClick.AddListener(BackToMainMenu);
        
       
    }
    
    // ======== Button Functions ========
    
    void PlayGame()
    {
        // Load your game scene
        SceneManager.LoadScene("Faisal-Map");
    }
    
    void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }
    
    void BackToMainMenu()
    {
        settingsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    
    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }
    
    // ======== Volume Functions ========
    
    void LoadVolumeSettings()
    {
        // Load saved values or use defaults (0.75 = 75%)
        float masterVol = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        
        // Set slider values
        masterVolumeSlider.value = masterVol;
        musicVolumeSlider.value = musicVol;
        sfxVolumeSlider.value = sfxVol;
        
       
    }
    
   
}