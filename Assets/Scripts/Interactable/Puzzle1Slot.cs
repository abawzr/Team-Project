using UnityEngine;

public class Puzzle1Slot : MonoBehaviour, IInteractable
{
    [SerializeField] private Puzzle1 puzzle; // Reference to the puzzle manager
    [SerializeField] private GameObject correctItem; // The item that belongs in this slot
    [SerializeField] private GameObject alreadyPlacedItem;

    private GameObject _currentItem;

    private void Awake()
    {
        if (alreadyPlacedItem != null)
        {
            alreadyPlacedItem.transform.position = transform.position;
            alreadyPlacedItem.SetActive(true);
            _currentItem = alreadyPlacedItem;
        }
    }

    public void Interact(PlayerInventory playerInventory)
    {
        if (puzzle.IsSolved) return;

        // Player has item AND slot is empty → place item
        if (playerInventory.HasItem() && _currentItem == null)
        {
            _currentItem = playerInventory.CurrentItem;
            playerInventory.PutItem(transform.position);
        }

        // Player has item AND slot has item → swap items
        else if (playerInventory.HasItem() && _currentItem != null)
        {
            GameObject slotItem = _currentItem;
            GameObject playerItem = playerInventory.CurrentItem;

            // Put player item into slot
            playerInventory.PutItem(transform.position);

            // Pick old slot item into player inventory
            playerInventory.PickItem(slotItem, slotItem.GetComponent<Item>().GetItemIcon());

            // Update slot reference
            _currentItem = playerItem;
        }

        // Player empty-handed AND slot has item → pick it up
        else if (!playerInventory.HasItem() && _currentItem != null)
        {
            GameObject slotItem = _currentItem;
            _currentItem = null;

            playerInventory.PickItem(slotItem, slotItem.GetComponent<Item>().GetItemIcon());
        }

        puzzle.CheckSolution();
    }

    public bool IsCorrect()
    {
        return _currentItem == correctItem;
    }
}
