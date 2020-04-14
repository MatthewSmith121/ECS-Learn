using UnityEngine;

public class MasterSpawnerController : MonoBehaviour
{
    public GameObject ballSpawner;
    public int spawnNumber;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnNumber; i++) {
            Instantiate(ballSpawner, transform);
        }
    }
}
