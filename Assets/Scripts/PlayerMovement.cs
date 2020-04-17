using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.81f;

    CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpSpeed = 3f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;

    private void Start() {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = (transform.right * x + transform.forward * z).normalized * speed * Time.deltaTime;

        controller.Move(move);

        controller.Move(velocity * Time.deltaTime);
    }
}
