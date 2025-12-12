using TMPro;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField, TextArea(5, 10)] private string noteText;
    [SerializeField] private GameObject notePanelUI;
    [SerializeField] private GameObject crosshairUI;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private AudioClip pickupSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && notePanelUI.activeSelf)
        {
            Time.timeScale = 1f;

            notePanelUI.SetActive(false);
            crosshairUI.SetActive(true);

            PlayerMovement.IsMovementInputOn = true;
            PlayerCamera.IsCameraInputOn = true;
            PlayerInteraction.IsPlayerReading = false;
        }
    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (!notePanelUI.activeSelf)
        {
            Time.timeScale = 0f;

            _audioSource.PlayOneShot(pickupSound);

            notePanelUI.SetActive(true);
            crosshairUI.SetActive(false);
            tmpText.text = noteText;

            PlayerMovement.IsMovementInputOn = false;
            PlayerCamera.IsCameraInputOn = false;
            PlayerInteraction.IsPlayerReading = true;
        }

    }
}
