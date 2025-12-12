using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private AudioClip pickupSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator PickupItem(PlayerInventory playerInventory)
    {
        _audioSource.PlayOneShot(pickupSound);

        yield return new WaitForSeconds(pickupSound.length);

        playerInventory.PickItem(gameObject, itemIcon);
    }

    public void Interact(PlayerInventory playerInventory)
    {
        StartCoroutine(PickupItem(playerInventory));
    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }
}
