using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    public GameObject ballSpawnerPrefab;

    private void Start() {
        for (int i = 0; i < Settings.GetNumberOfSpawners(); i++) {
            Instantiate(ballSpawnerPrefab, transform);
        }
    }
}
