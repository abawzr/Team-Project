using TMPro;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField, TextArea(5, 10)] private string noteText;
    [SerializeField] private GameObject notePanelUI;
    [SerializeField] private TMP_Text tmpText;

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
        notePanelUI.SetActive(true);
        tmpText.text = noteText;
        PlayerMovement.IsMovementInputOn = false;
        PlayerCamera.IsCameraInputOn = false;
    }
}
