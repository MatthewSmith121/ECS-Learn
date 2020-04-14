using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Rigidbody playerRigidbody;

    float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Vector3 playerRot = new Vector3(0f, mouseX, 0f);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Camera Rotate
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player Rotate
        //playerBody.Rotate(Vector3.up * mouseX);
        playerRigidbody.rotation = Quaternion.Euler(playerRigidbody.rotation.eulerAngles + playerRot);

    }
}
