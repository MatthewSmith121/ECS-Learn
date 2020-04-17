using Unity.Entities;
using UnityEngine;

public class PlayerController : MonoBehaviour, IConvertGameObjectToEntity
{
    void Start() {
        // Turn off box collider so it doesn't interfere with CharacterController
        // still need it though for entity conversion
        GetComponent<BoxCollider>().enabled = false;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(PlayerTag));
    }
}
