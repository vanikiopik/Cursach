using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;

    // Min&Max camera vertical angle
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;

    // Current camera angle
    private Vector2 currentRotation = new Vector2(0,0);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotation.x += mouseX * sensitivity * Time.deltaTime;
        currentRotation.y -= mouseY * sensitivity * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minVerticalAngle, maxVerticalAngle);
        transform.localEulerAngles = new Vector3(currentRotation.y, currentRotation.x, 0f);
    }
}
