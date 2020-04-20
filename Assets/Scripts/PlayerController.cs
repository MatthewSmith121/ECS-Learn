using Unity.Entities;
using UnityEngine;

public class PlayerController : MonoBehaviour, IConvertGameObjectToEntity
{
    public CanvasController canvas;
    Vector3 startingPosition;
    CharacterController controller;

    void Start() {
        // Turn off box collider so it doesn't interfere with CharacterController
        // still need it though for entity conversion
        GetComponent<BoxCollider>().enabled = false;
        startingPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(PlayerTag));
    }

    public void PlayerDied() {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<PlayerLook>().enabled = false;
        canvas.Lose();
    }

    public void PlayerWon() {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<PlayerLook>().enabled = false;
        canvas.Win();
    }

    public void Reset() {
        // Reset Position
        controller.enabled = false;
        transform.position = startingPosition;
        controller.enabled = true;

        // Re-enable movement
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponentInChildren<PlayerLook>().enabled = true;
    }
}
