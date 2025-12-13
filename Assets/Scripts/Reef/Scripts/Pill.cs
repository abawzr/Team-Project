using UnityEngine;

public class Pill : MonoBehaviour, IInteractable
{
    [SerializeField] private float doseAmount;
    public void Interact(PlayerInventory playerInventory)
    {
        Health.Instance.AddDrug(doseAmount);

        gameObject.SetActive(false);
    }

}

