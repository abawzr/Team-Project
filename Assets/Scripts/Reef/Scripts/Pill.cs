using UnityEngine;

public class Pill : MonoBehaviour, IInteractable
{
    [SerializeField] private float doseAmount = 150f;
    public void Interact(PlayerInventory playerInventory)
    {
        Health.Instance.AddDrug(doseAmount);

        gameObject.SetActive(false);
    }

}

