using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator _animator;
    private bool _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (!_isOpen)
        {
            _isOpen = true;
            _animator.SetBool("IsOpen", true);
        }

        else if (_isOpen)
        {
            _isOpen = false;
            _animator.SetBool("IsOpen", false);
        }
    }
}
