using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(-10, 5, 0);

    public float movementSpeed = 100f;
    public float rotationSpeed = 200f;
    public float tiltAngle = 30f;

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //Check for right mouse button input
        if(Input.GetMouseButtonDown(1))
        {
            isMoving = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isMoving = false;
        }
        //Free camera, move camera based on mouse
        if (isMoving)
    {
        
        //Move the player in direction of the camera
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Mouse X");
        float tilt = Input.GetAxis("Mouse Y");

        //Move camera horizontally and forward/backward 
        transform.Translate(Vector3.right * horizontal * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vertical * movementSpeed * Time.deltaTime);

        //Rotate camera horizontally
        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        float newTiltAngle = transform.rotation.eulerAngles.x - tilt * rotationSpeed * Time.deltaTime;
        newTiltAngle = Mathf.Clamp(newTiltAngle, -tiltAngle, tiltAngle);
        transform.rotation = Quaternion.Euler(newTiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    else
    {
        //Set the camera position relative to the player's position
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * movementSpeed);

        //Rotate the camera to face the player
        Quaternion desiredRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
    }

}


