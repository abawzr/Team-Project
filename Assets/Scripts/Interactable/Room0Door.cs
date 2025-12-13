using UnityEngine;

public class Room0Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hammer;
    [SerializeField] private AudioClip breakDoorClip;
    [SerializeField] private AudioClip lockedDoorClip;

    private AudioSource _audioSource;

    public static bool IsSolved = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (playerInventory.CurrentItem == hammer)
        {
            playerInventory.UseItem();
            _audioSource.PlayOneShot(breakDoorClip);
            transform.localRotation = Quaternion.Euler(0f, -122f, 0f);
            IsSolved = true;
            Destroy(this);
        }

        else
        {
            _audioSource.PlayOneShot(lockedDoorClip);
        }
    }
}
