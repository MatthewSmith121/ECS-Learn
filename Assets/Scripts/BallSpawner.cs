﻿using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class BallSpawner : MonoBehaviour
{
    public bool useEcs;

    [Header("Non-Ecs")]
    public GameObject[] ballPrefabs;
    int spawnNumber = 600;
    int spawnCount = 0;

    [Header("ECS")]
    EntityManager manager;
    Entity[] ballEntityPrefabs;

    void Start() {
        if (useEcs) {
            ballEntityPrefabs = new Entity[ballPrefabs.Length];
            manager = World.Active.EntityManager;
            // Turn GameObject into Entity
            for (int i = 0; i < ballPrefabs.Length; i++) {
                ballEntityPrefabs[i] = GameObjectConversionUtility.ConvertGameObjectHierarchy(ballPrefabs[i], World.Active);
            }
        }
    }

    private void Update() {
        if (spawnCount < spawnNumber) {
            float x = Random.Range(-45f, 45f);
            float z = Random.Range(-45f, 45f);
            if (useEcs) {
                SpawnBallECS(new Vector3(x, 10, z));
            } else {
                Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], new Vector3(x, 10, z), Quaternion.identity);
            }
            spawnCount++;
        }
    }

    private void SpawnBallECS(Vector3 location) {
        // The Entity is just a way to find data
        Entity ball = manager.Instantiate(ballEntityPrefabs[Random.Range(0, ballEntityPrefabs.Length)]);
        // Add data associated with the Entity
        manager.SetComponentData(ball, new Translation { Value = location });
    }
}
