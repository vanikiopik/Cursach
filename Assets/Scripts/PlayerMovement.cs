using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 2f;


    private Rigidbody rb;
    private Camera mainCamera;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;


        moveDirection = mainCamera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;

        rb.velocity = moveDirection * moveSpeed;

        rb.AddForce(Vector3.down * gravityScale);
    }
}
