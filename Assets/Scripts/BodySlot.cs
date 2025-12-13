using System.Collections.Generic;
using UnityEngine;

public class BodySlot : MonoBehaviour, IInteractable
{
    [SerializeField] private BodyPuzzle puzzle;
    [SerializeField] private int requiredWeight;

    private List<GameObject> _itemsInSlot = new List<GameObject>();

    public void Interact(PlayerInventory playerInventory)
    {
        if (puzzle.IsSolved) return;

        if (!Health.CanSeeBodyParts) return;

        if (playerInventory.HasItem())
        {
            GameObject heldItem = playerInventory.CurrentItem;

            if (!heldItem.TryGetComponent<BodyPart>(out _))
                return;

            _itemsInSlot.Add(heldItem);

            Vector3 basePos = transform.position;
            Vector3 offset = new Vector3(0.15f * (_itemsInSlot.Count - 1), 0f, 0f);

            if (_itemsInSlot.Count > 4)
            {
                offset = new Vector3(0.15f * (_itemsInSlot.Count - 4 - 1), 0f, 0.2f);

                if (_itemsInSlot.Count > 8)
                {
                    offset = new Vector3(0.15f * (_itemsInSlot.Count - 8 - 1), 0f, 0.4f);
                }
            }

            playerInventory.PutItem(basePos + offset);
            heldItem.transform.rotation = transform.rotation;
        }

        else if (!playerInventory.HasItem() && _itemsInSlot.Count > 0)
        {
            GameObject lastItem = _itemsInSlot[_itemsInSlot.Count - 1];
            _itemsInSlot.RemoveAt(_itemsInSlot.Count - 1);

            BodyPart itemScript = lastItem.GetComponent<BodyPart>();
            Sprite icon = itemScript != null ? itemScript.GetBodyPartIcon() : null;

            playerInventory.PickItem(lastItem, icon);
        }

        puzzle.CheckSolution();
    }

    public bool IsCorrect()
    {
        int totalWeight = 0;

        foreach (var go in _itemsInSlot)
        {
            if (go == null) continue;

            var part = go.GetComponent<BodyPart>();
            if (part != null)
                totalWeight += part.Weight;
        }

        return totalWeight == requiredWeight;
    }
}
