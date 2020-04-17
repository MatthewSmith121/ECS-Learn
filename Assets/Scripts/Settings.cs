using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    static Settings instance;

    [Header("Game Object References")]
    public Transform player;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    public static Vector3 PlayerPosition {
        get { return instance.player.position; }
    }

    public static Quaternion PlayerRotation {
        get { return instance.player.rotation;  }
    }
}
