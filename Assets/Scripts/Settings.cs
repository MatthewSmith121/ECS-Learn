using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Settings : MonoBehaviour
{
    static Settings instance;
    int itemsActivated;
    int doneSpawning;
    bool playerOnPedestal;

    [Header("Game Object References")]
    public Transform player;
    public Transform creature;
    GameObject[] pedestalColliders;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        pedestalColliders = GameObject.FindGameObjectsWithTag("Pedestal Collider");
    }

    public static Vector3 PlayerPosition {
        get { return instance.player.position; }
    }

    public static Quaternion PlayerRotation {
        get { return instance.player.rotation;  }
    }

    public static void ItemActivated() {
        instance.itemsActivated++;
        if (instance.itemsActivated >= 4) {
            instance.player.GetComponent<PlayerController>().PlayerWon();
            instance.creature.GetComponent<CreatureController>().SetGameOver(true);
        }
    }

    public static void SpawnerFinished() {
        instance.doneSpawning++;
        // Turn pedestal colliders to triggers
        if (instance.doneSpawning >= 21) {
            foreach (GameObject sc in instance.pedestalColliders) {
                sc.GetComponent<SphereCollider>().isTrigger = true;
            }
        }
    }

    public static bool DoneSpawning() {
        return instance.doneSpawning >= 21;
    }

    public static void TogglePlayerOnPedestal() {
        instance.playerOnPedestal = !instance.playerOnPedestal;
    }

    public static bool isPlayerOnPedestal() {
        return instance.playerOnPedestal;
    }
}
