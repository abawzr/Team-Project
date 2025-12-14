// Script by Marcelli Michele

using System;
using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;

    public Animator boxAnimator;  // ADD THIS: Reference to the box's animator

    public AudioSource audioSource;
    public AudioClip audioClip;

    public int[] _numberPassword = { 0, 0, 0, 0 };

    private bool isUnlocked = false;

    private void Awake()
    {
        if (_moveRull == null)
            _moveRull = FindObjectOfType<MoveRuller>();
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

            // ADD THIS: Open the box too!
            if (boxAnimator != null)
            {
                boxAnimator.SetTrigger("Open");  // Make sure your box has an "open" trigger
                audioSource.PlayOneShot(audioClip);
            }

            // Disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }
        }
    }
}