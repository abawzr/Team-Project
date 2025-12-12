using System.Collections.Generic;
using UnityEngine;

public class ItemsRespawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Item> excludedItemsFromRandomRespawn;

    private void Start()
    {
        int randomIndex;

        if (spawnPoints.Count == 0) return;

        foreach (Item item in FindObjectsOfType<Item>(includeInactive: true))
        {
            if (excludedItemsFromRandomRespawn.Contains(item)) continue;

            randomIndex = Random.Range(0, spawnPoints.Count);
            item.transform.position = spawnPoints[randomIndex].position;
            spawnPoints.Remove(spawnPoints[randomIndex]);
            item.gameObject.SetActive(true);
        }
    }
}
