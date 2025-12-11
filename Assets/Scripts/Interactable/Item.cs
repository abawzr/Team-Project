/*using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{

    [Header("Sound Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;
    public void Interact(PlayerInventory playerInventory)
    {


        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
        playerInventory.PickItem(gameObject);
    }
}
*/

using System;
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


    public void Interact(PlayerInventory playerInventory)
    {
        StartCoroutine(PickupSound(playerInventory));
    }

    private IEnumerator PickupSound(PlayerInventory playerInventory)
    {
        audioSource.PlayOneShot(pickupSound);
        yield return new WaitForSeconds(pickupSound.length);
        playerInventory.PickItem(gameObject);
    }
}
