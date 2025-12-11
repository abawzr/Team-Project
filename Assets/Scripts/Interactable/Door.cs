using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private float volume = 1f;
    private AudioSource audioSource;

    private Animator _animator;
    private bool _isOpen;
   

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (!_isOpen)
        {
            _isOpen = true;
            _animator.SetBool("IsOpen", true);
            
            if (openSound != null)
            {
                audioSource.PlayOneShot(openSound, volume);
            }
        }

        else if (_isOpen)
        {
            _isOpen = false;
            _animator.SetBool("IsOpen", false);
            if (closeSound != null)
            {
                audioSource.PlayOneShot(closeSound, volume);
            }
        }
    }
}
