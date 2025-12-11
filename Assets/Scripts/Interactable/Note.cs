using TMPro;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField, TextArea(5, 10)] private string noteText;
    [SerializeField] private GameObject notePanelUI;
    [SerializeField] private TMP_Text tmpText;
    
    
    [Header("Sound Settings")]
    [SerializeField] private AudioSource audioSource;   
    [SerializeField] private AudioClip pickupSound;    


    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && notePanelUI.activeSelf)
        {
            notePanelUI.SetActive(false);
            PlayerMovement.IsMovementInputOn = true;
            PlayerCamera.IsCameraInputOn = true;
        }
    }

    public void Interact(PlayerInventory playerInventory)
    {
        
        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
        
        notePanelUI.SetActive(true);
        tmpText.text = noteText;
        PlayerMovement.IsMovementInputOn = false;
        PlayerCamera.IsCameraInputOn = false;
    }
}
