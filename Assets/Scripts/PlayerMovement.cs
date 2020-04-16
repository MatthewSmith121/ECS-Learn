using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.81f;

    Rigidbody playerRigidbody;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpSpeed = 3f;
    public LayerMask groundMask;
    bool isGrounded;

    private void Start() {
        playerRigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            // TODO: add jumping
        }

        Vector3 move = (transform.right * x + transform.forward * z).normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + move);
    }
}
