using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float distance = 5f;
    public float height = 2f;
    public float sensitivity = 0.2f;
    public float moveSpeed = 5f;

    private float rotateX = 0f;
    private float rotateY = 0f;

    public bool isMoving = false;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, height, -distance);
        offset = transform.position - target.transform.position;

    }


    // Update is called once per frame
    private void LateUpdate()
    {
        

        //Calculate camera position based on target position and camera offset
        Vector3 playerPosition = target.position + offset;
        transform.position = playerPosition;

        if (Input.GetMouseButtonDown(1))
        {
            isMoving = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isMoving = false;
        }

        //Only move character if camera is being controlled
        if (isMoving)
        {
        Vector3 direction = (target.position - transform.position).normalized;
        float yRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        rotateX -= Input.GetAxis("Mouse Y") *sensitivity;
        rotateX = Mathf.Clamp(rotateX, -80f, 80f);
        rotateY += Input.GetAxis("Mouse X") * sensitivity;

        Quaternion rotation = Quaternion.Euler(rotateX, rotateY, 0);
        Vector3 offsetY = Vector3.up * height;
        offset = rotation * new Vector3(0, offsetY.y, -distance);

        transform.position = target.position + offset + offsetY;
        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0f);

        //Get input axes for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Create a movement vector based on the input axes
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        //Rotate the movement vector based on the camera's rotation
        movementDirection = rotation * movementDirection;

        //Move the character in the rotated movement direction
        target.position += movementDirection * Time.deltaTime * moveSpeed;
        }

        //Set camera position and rotation
        transform.position = playerPosition;
        transform.LookAt(target.position);
        
    }
}
