using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float obstacleRange;
    public float avoidSpeed;
    public float lookAhead;
    public float rotationSpeed;

    private bool _isAvoiding = false;

    void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, obstacleRange))
        {
            _isAvoiding = true;
        }
        else
        {
            _isAvoiding = false;
        }

        if (_isAvoiding)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * avoidSpeed);
        }
        else
        {
            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
