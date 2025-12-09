using UnityEngine;

public class Pill : MonoBehaviour, IInteractable
{
    [SerializeField] private float doseAmount = 5f;
    public void Interact(PlayerInventory playerInventory)
    {

        HealthManager.Instance.AddDrug(doseAmount);

        gameObject.SetActive(false);
    }

}

