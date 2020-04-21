using UnityEngine;
using Unity.Entities;

[RequireComponent(typeof(Rigidbody))]
public class CreatureController : MonoBehaviour, IConvertGameObjectToEntity
{
    public Transform player;
    public float rotationSpeed = 1f;
    public GameObject startingPathObject;
    GameObject destinationPathObject;
    public float speed = 3f;
    public float playerThreshold = 40f;
    public float loseThreshold = 5f;
    bool gameOver;
    public bool toggleLose = true;
    Rigidbody body;

    void Start() {
        InitializePosition();
        Physics.IgnoreLayerCollision(9, 8); // Ignore collision between creature and floor
        body = GetComponent<Rigidbody>();
    }

    private void InitializePosition() {
        transform.position = new Vector3(startingPathObject.transform.position.x, transform.position.y, startingPathObject.transform.position.z);
        destinationPathObject = startingPathObject;
    }

    void Update()
    {
        if (gameOver) {
            return;
        }
        // Rotate towards a target destination, either player or ai path object
        Transform target = destinationPathObject.transform; /// default to this

        // If player is nearby, move toward player
        if (Vector3.Distance(player.position, transform.position) < playerThreshold && !Settings.isPlayerOnPedestal()) {
            if (Vector3.Distance(player.position, transform.position) < loseThreshold) {
                player.GetComponent<PlayerController>().PlayerDied();
                SetGameOver(true);
                return;
            }
            // Face the player
            target = player;
        }
        else {
            // If we have reached our destination, pick a new pathObject to go to
            if (Vector3.Distance(transform.position, destinationPathObject.transform.position) < 8f) {
                destinationPathObject.GetComponent<PathObject>().Visited();
                destinationPathObject = GetNewDestinationTarget(destinationPathObject.GetComponent<PathObject>());
            }

            target = destinationPathObject.transform;
        }

        Vector3 direction = (EqualLevel(target.position) - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);

        body.MovePosition(body.position + transform.forward * speed * Time.deltaTime);
    }

    private GameObject GetNewDestinationTarget(PathObject po) {
        int min = 9999;
        GameObject nextTarget = null;
        for (int i = 0; i < po.neighbours.Length; i++) {
            PathObject neighbour = po.neighbours[i].GetComponent<PathObject>();
            if (neighbour.GetVisitNumber() < min) {
                nextTarget = po.neighbours[i];
                min = neighbour.GetVisitNumber();
            }
        }

        if (nextTarget == null) {
            nextTarget = po.neighbours[0];
        }
        return nextTarget;
    }


    // Entity conversion can't handle both trigger collider and non-trigger collider
    /*private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && toggleLose) {
            other.gameObject.GetComponent<PlayerController>().PlayerDied();
            SetGameOver(true);
        }   
    }*/

    public void SetGameOver(bool val) {
        gameOver = val;
    }

    private Vector3 EqualLevel(Vector3 v) {
        return new Vector3(v.x, transform.position.y, v.z);
    }

    public void Reset() {
        // Resest position and destination
        InitializePosition();

        // Game not over
        gameOver = false;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        dstManager.AddComponent(entity, typeof(CreatureTag));
    }
}
