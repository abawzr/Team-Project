// Script by Marcelli Michele

using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;
    
    public Animator animator;
    public Animator boxAnimator;  // Reference to the box's animator
    
    public AudioSource audioSource;
    public AudioClip boxOpenSound;  // Drag your sound clip here in the Inspector
    
    public int[] _numberPassword = {0,0,0,0};
    
    private bool isUnlocked = false;

    private void Awake()
    {
        if (_moveRull == null)
            _moveRull = FindObjectOfType<MoveRuller>();
    
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Password();
    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword) && !isUnlocked)
        {
            isUnlocked = true;  // Prevent this from running multiple times
            
            // Here enter the event for the correct combination
            Debug.Log("Password correct");
            
            animator.SetTrigger("open");
            
            // Open the box with sound
            if (boxAnimator != null)
            {
                StartCoroutine(OpenBox());
            }

            // Disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }
        }
    }
    
    private IEnumerator OpenBox()
    {
        audioSource.PlayOneShot(boxOpenSound);
        
        yield return new WaitForSeconds(boxOpenSound.length);
        
        boxAnimator.SetTrigger("open");
    }
}