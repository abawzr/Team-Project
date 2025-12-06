using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Image uiItemImage;
    [SerializeField] private TMP_Text uiItemText;

    private GameObject _currentItem;

    public bool HasItem(GameObject item)
    {
        return item == _currentItem;
    }

    public void UseItem()
    {
        Destroy(_currentItem);
        _currentItem = null;
        uiItemImage.sprite = null;
        uiItemImage.enabled = false;
        uiItemText.text = string.Empty;
    }

    public void PickItem(GameObject item, Sprite itemIcon)
    {
        if (_currentItem != null)
        {
            _currentItem.transform.position = item.transform.position;
            _currentItem.transform.rotation = Quaternion.identity;
            _currentItem.transform.localScale = Vector3.one;
            _currentItem.SetActive(true);
        }

        _currentItem = item;
        uiItemImage.sprite = itemIcon;
        uiItemImage.enabled = true;
        uiItemText.text = item.name;
        item.SetActive(false);
    }
}
