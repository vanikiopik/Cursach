using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public float sensitivity = 100f;

    // Min&Max camera vertical angle
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;

    // Current camera angle
    private Vector2 currentRotation = Vector2.one;

    private void Update()
    {
        /*// ƒвижение камеры по горизонтали и вертикали
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        

        moveDirection = Vector3.ClampMagnitude(moveDirection, moveSpeed);

        if(_characterController.isGrounded)
            moveDirection.y -= _gravity  * Time.deltaTime;
        else
        {
            moveDirection.y -= _gravity * Time.deltaTime * 50f;
        }

        
        moveDirection = transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;

        _characterController.Move(moveDirection);*/


        // ѕоворот камеры по горизонтали и вертикали
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotation.x += mouseX * sensitivity * Time.deltaTime;
        currentRotation.y -= mouseY * sensitivity * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minVerticalAngle, maxVerticalAngle);
        transform.localEulerAngles = new Vector3(currentRotation.y, currentRotation.x, 0f);
    }
}
