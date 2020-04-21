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
    int numberOfSpawners = 20;

    [Header("Game Object References")]
    public Transform player;
    public Transform creature;
    GameObject[] pedestalColliders;
    GameObject[] activatableItems;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        pedestalColliders = GameObject.FindGameObjectsWithTag("Pedestal Collider");
        activatableItems = GameObject.FindGameObjectsWithTag("Activatable");
    }

    public static Vector3 PlayerPosition {
        get { return instance.player.position; }
    }

    public static Quaternion PlayerRotation {
        get { return instance.player.rotation; }
    }

    public static Vector3 CreaturePosition {
        get { return instance.creature.position; }
    }

    public static Quaternion CreatureRotation {
        get { return instance.creature.rotation; }
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
        if (instance.doneSpawning >= instance.numberOfSpawners) {
            foreach (GameObject sc in instance.pedestalColliders) {
                sc.GetComponent<SphereCollider>().isTrigger = true;
            }
        }
    }

    public static int GetNumberOfSpawners() {
        return instance.numberOfSpawners;
    }

    public static bool DoneSpawning() {
        return instance.doneSpawning >= instance.numberOfSpawners;
    }

    public static void TogglePlayerOnPedestal() {
        instance.playerOnPedestal = !instance.playerOnPedestal;
    }

    public static bool isPlayerOnPedestal() {
        return instance.playerOnPedestal;
    }

    public static void Restart() {
        // Reset Player
        instance.player.GetComponent<PlayerController>().Reset();

        // Reset Creature
        instance.creature.GetComponent<CreatureController>().Reset();

        // Reset Canvas
        // ** Done in restart click in canvas controller ** //

        // Reset Magic Items
        foreach (GameObject go in instance.activatableItems) {
            go.GetComponent<Activate>().Reset();
        }

        // Reset Settings
        instance.itemsActivated = 0;
        instance.playerOnPedestal = false;
    }
}
