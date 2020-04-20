using Unity.Entities;
using UnityEngine;

public class PlayerController : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject winText;
    public GameObject loseText;

    void Start() {
        // Turn off box collider so it doesn't interfere with CharacterController
        // still need it though for entity conversion
        GetComponent<BoxCollider>().enabled = false;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(PlayerTag));
    }

    public void PlayerDied() {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<PlayerLook>().enabled = false;
        loseText.SetActive(true);
    }

    public void PlayerWon() {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<PlayerLook>().enabled = false;
        winText.SetActive(true);
    }

    public void Reset() {
        loseText.SetActive(false);
        winText.SetActive(false);
    }
}
