using System.Collections.Generic;
using UnityEngine;

public class BodySlot : MonoBehaviour, IInteractable
{
    [SerializeField] private BodyPuzzle puzzle;
    [SerializeField] private int requiredWeight = 50;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private List<GameObject> _itemsInSlot = new List<GameObject>();

    public void Interact(PlayerInventory playerInventory)
    {
        if (puzzle.IsSolved) return;

        if (playerInventory.HasItem())
        {
            GameObject heldItem = playerInventory.CurrentItem;

            if (!heldItem.TryGetComponent<BodyPart>(out _))
                return;

            _itemsInSlot.Add(heldItem);

            //  offset مالها داعي  
            Vector3 basePos = transform.position;
            Vector3 offset = new Vector3(0.15f * (_itemsInSlot.Count - 1), 0f, 0f);

            playerInventory.PutItem(basePos + offset);
            heldItem.transform.rotation = transform.rotation;
        }

        else if (!playerInventory.HasItem() && _itemsInSlot.Count > 0)
        {
            GameObject lastItem = _itemsInSlot[_itemsInSlot.Count - 1];
            _itemsInSlot.RemoveAt(_itemsInSlot.Count - 1);

            Item itemScript = lastItem.GetComponent<Item>();
            Sprite icon = itemScript != null ? itemScript.GetItemIcon() : null;

            playerInventory.PickItem(lastItem, icon);
        }

        puzzle.CheckSolution();

        if (!puzzle.IsSolved)
        {
           // PlayWrongWeightsound();
        }
    }

    public bool IsCorrect()
    {
        int totalWeight = 0;

        //0
        foreach (var go in _itemsInSlot)
        {
            if (go == null) continue;

            var part = go.GetComponent<BodyPart>();
            if (part != null)
                totalWeight += part.weight;
        }

        return totalWeight == requiredWeight;
    }
    private void Playsound()
    {
        float totalWeight = GetCurrentWeight();

        if (totalWeight == requiredWeight)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    private float GetCurrentWeight()
    {
        float totalWeight = 0f;

        foreach (var go in _itemsInSlot)
        {
            if (go == null) continue;

            var part = go.GetComponent<BodyPart>();
            if (part != null)
                totalWeight += part.weight;
        }

        return totalWeight;
    }
}
