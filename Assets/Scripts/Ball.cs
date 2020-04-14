using UnityEngine;
using Unity.Entities;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour, IConvertGameObjectToEntity
{

    void Start() {
        Color colour;
        switch (Random.Range(0, 3)) {
            case 0:
                colour = Color.red;
                break;
            case 1:
                colour = Color.blue;
                break;
            case 2:
                colour = Color.green;
                break;
            default:
                colour = Color.red;
                break;
        };

        gameObject.GetComponent<Renderer>().material.color = colour;
    }

    // Need to add data that is unique to the entity here
    // Generic things such as transforms or rigidbodies get converted automatically
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        
    }
}
