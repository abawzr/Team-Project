using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Image uiItemImage;
    [SerializeField] private TMP_Text uiItemText;
    [SerializeField] private AudioClip pickItemClip;
    [SerializeField] private AudioClip putItemClip;

    private AudioSource _audioSource;

    public GameObject CurrentItem { get; private set; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool HasItem()
    {
        return CurrentItem != null;
    }

    public void UseItem()
    {
        Destroy(CurrentItem);
        CurrentItem = null;
        uiItemImage.sprite = null;
        uiItemImage.enabled = false;
        uiItemText.text = string.Empty;
    }

    public void PickItem(GameObject item, Sprite itemIcon)
    {
        _audioSource.PlayOneShot(pickItemClip);

        if (CurrentItem != null)
        {
            CurrentItem.transform.position = item.transform.position;

            CurrentItem.SetActive(true);
        }

        CurrentItem = item;

        uiItemImage.sprite = itemIcon;
        uiItemImage.enabled = true;
        uiItemText.text = item.name;

        item.SetActive(false);
    }

    public void PutItem(Vector3 placePoint)
    {
        // There is no item in inventory
        if (CurrentItem == null) return;

        _audioSource.PlayOneShot(putItemClip);

        CurrentItem.transform.position = placePoint;

        CurrentItem.SetActive(true);
        CurrentItem = null;

        uiItemImage.sprite = null;
        uiItemImage.enabled = false;
        uiItemText.text = string.Empty;
    }
}
