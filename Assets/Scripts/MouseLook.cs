using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private void Start()
    {
        xRotation -= 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        // Stops the camera from looking past these values
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}