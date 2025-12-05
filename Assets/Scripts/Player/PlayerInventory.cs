using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private GameObject _currentItem;

    public bool HasItem(GameObject item)
    {
        return item == _currentItem;
    }

    public void UseItem()
    {
        Destroy(_currentItem);
        _currentItem = null;
    }

    public void PickItem(GameObject item)
    {
        if (_currentItem != null)
        {
            _currentItem.transform.position = item.transform.position;
            _currentItem.transform.rotation = Quaternion.identity;
            _currentItem.transform.localScale = Vector3.one;
            _currentItem.SetActive(true);
        }

        _currentItem = item;
        item.SetActive(false);
    }
}
