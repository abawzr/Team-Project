using UnityEngine;

public class BodyPart : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite bodyPartIcon;

    public int Weight { get; private set; }

    public void Interact(PlayerInventory playerInventory)
    {
        playerInventory.PickItem(gameObject, bodyPartIcon);
    }

    public Sprite GetBodyPartIcon()
    {
        return bodyPartIcon;
    }
}
