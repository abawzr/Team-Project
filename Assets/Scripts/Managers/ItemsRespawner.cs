using System.Collections.Generic;
using UnityEngine;

public class ItemsRespawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> excludedItemsFromRandomRespawn;

    private void Start()
    {
        int randomIndex;

        if (spawnPoints.Count == 0) return;

        foreach (Item item in FindObjectsOfType<Item>(includeInactive: true))
        {
            if (excludedItemsFromRandomRespawn.Contains(item.gameObject)) continue;

            randomIndex = Random.Range(0, spawnPoints.Count);
            item.transform.position = spawnPoints[randomIndex].position;
            spawnPoints.Remove(spawnPoints[randomIndex]);
            item.gameObject.SetActive(true);
        }

        foreach (BodyPart bodyPart in FindObjectsOfType<BodyPart>(includeInactive: true))
        {
            if (excludedItemsFromRandomRespawn.Contains(bodyPart.gameObject)) continue;

            randomIndex = Random.Range(0, spawnPoints.Count);
            bodyPart.transform.position = spawnPoints[randomIndex].position;
            spawnPoints.Remove(spawnPoints[randomIndex]);
            bodyPart.gameObject.SetActive(true);
        }

        foreach (Pill pill in FindObjectsOfType<Pill>(includeInactive: true))
        {
            if (excludedItemsFromRandomRespawn.Contains(pill.gameObject)) continue;

            randomIndex = Random.Range(0, spawnPoints.Count);
            pill.transform.position = spawnPoints[randomIndex].position;
            spawnPoints.Remove(spawnPoints[randomIndex]);
            pill.gameObject.SetActive(true);
        }
    }
}
