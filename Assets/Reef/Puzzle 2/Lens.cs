using UnityEngine;

public class Lens : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject [] bodyparts;
    //[SerializeField] private AudioSource drink;

    private bool _used = false;

    private void Start()
    {
        for (int i = 0; i < bodyparts.Length; i++)
        {
            bodyparts[i].SetActive(false);
        }
    }
    public void Interact(PlayerInventory playerInventory) { 
     
        if (_used) {return; }
        _used = true;

        for (int i = 0; i < bodyparts.Length; i++) {
            bodyparts[i].SetActive(true);
        }
    
       //drink.Play();
     
        gameObject.SetActive(false);
    }

}
