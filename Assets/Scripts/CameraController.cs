using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �������� �������� ������
    public float moveSpeed;
    private float _gravity = 9.8f;
    // ���������������� ����
    public float sensitivity = 100f;

    // ����������� � ������������ ���� �������� ������ �� ���������
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;

    // ������� ���� �������� ������
    private Vector2 currentRotation = Vector2.right;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // �������� ������ �� ����������� � ���������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        moveDirection = Vector3.ClampMagnitude(moveDirection, moveSpeed);

        moveDirection.y -= _gravity * Time.deltaTime;

        moveDirection = moveDirection * Time.deltaTime;
        
        moveDirection = transform.TransformDirection(moveDirection);

        _characterController.Move(moveDirection);


        // ������� ������ �� ����������� � ���������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        currentRotation.x += mouseX * sensitivity * Time.deltaTime;
        currentRotation.y -= mouseY * sensitivity * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minVerticalAngle, maxVerticalAngle);
        transform.localEulerAngles = new Vector3(currentRotation.y, currentRotation.x, 0f);
    }
}
