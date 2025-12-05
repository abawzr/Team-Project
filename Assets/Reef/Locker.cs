using UnityEngine;

public class Locker : MonoBehaviour, IInteractable
{

    [SerializeField] private Transform hidePoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private PlayerMovement player;

    private CharacterController _characterController;
    // searching for a butter name 
    private bool _isHid = true;

    private void Awake()
    {
        //if
        _characterController= player.GetComponent<CharacterController>();
    }
    public void Interact(PlayerInventory playerInventory)
    {
        Debug.Log("ttttttt");
     if (_isHid)  
      Hide();
    else
      Show();     
    }

    public void Hide() { 
    
        player.isHiding = true;
        _isHid = true;

        _characterController.enabled = false;
        player.transform.position = hidePoint.position;
        player.transform.rotation = hidePoint.rotation;
       


    }

    public void Show() {

        player.isHiding = false;
        _isHid = false;

       // _characterController.enabled = false;
        player.transform.position = exitPoint.position;
        _characterController.enabled = true;

    }

    
}
