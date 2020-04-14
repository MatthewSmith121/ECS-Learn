using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class BallSpawner : MonoBehaviour
{
    public bool useEcs;

    [Header("Non-Ecs")]
    public GameObject[] ballPrefabs;
    public int spawnNumber = 1000;
    int spawnCount = 0;
    public float spawnBound = 500f;

    [Header("ECS")]
    EntityManager manager;
    Entity[] ballEntityPrefabs;

    void Start() {
        if (useEcs) {
            ballEntityPrefabs = new Entity[ballPrefabs.Length];
            manager = World.DefaultGameObjectInjectionWorld.EntityManager;
            // Turn GameObject into Entity
            for (int i = 0; i < ballPrefabs.Length; i++) {
                ballEntityPrefabs[i] = GameObjectConversionUtility.ConvertGameObjectHierarchy(ballPrefabs[i], GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null));
            }
        }
    }

    private void Update() {
        if (spawnCount < spawnNumber) {
            float x = Random.Range(-spawnBound, spawnBound);
            float z = Random.Range(-spawnBound, spawnBound);
            if (useEcs) {
                SpawnBallECS(new Vector3(x, 10, z));
            } else {
                Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], new Vector3(x, 10, z), Quaternion.identity);
            }
            spawnCount++;
        } else {
            Destroy(gameObject);
        }
    }

    private void SpawnBallECS(Vector3 location) {
        // The Entity is just a way to find data
        Entity ball = manager.Instantiate(ballEntityPrefabs[Random.Range(0, ballEntityPrefabs.Length)]);
        // Add data associated with the Entity
        manager.SetComponentData(ball, new Translation { Value = location });
    }
}
