using UnityEngine;
using Unity.Entities;

public class PedestalColliderController : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(PedestalColliderTag));
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Settings.TogglePlayerOnPedestal();
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            Settings.TogglePlayerOnPedestal();
        }
    }
}
