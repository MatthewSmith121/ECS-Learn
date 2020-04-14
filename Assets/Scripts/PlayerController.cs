using Unity.Entities;
using UnityEngine;

public class PlayerController : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(PlayerTag));
    }
}
