using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour, IInteractable
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float volume = 1f;
    
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    [SerializeField] private Sprite itemIcon;

    public void Interact(PlayerInventory playerInventory)
    {
        playerInventory.PickItem(gameObject, itemIcon);
        StartCoroutine(PickupSound(playerInventory));

    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }

    private IEnumerator PickupSound(PlayerInventory playerInventory)
    {
        audioSource.PlayOneShot(pickupSound);
        yield return new WaitForSeconds(pickupSound.length);
        playerInventory.PickItem(gameObject, itemIcon);
    }
}
