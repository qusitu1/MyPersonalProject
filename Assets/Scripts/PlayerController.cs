using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float speed = 10f;
    public float horizontalInput;
    public float verticalInput;
    //Jump
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
       
        MovePlayer();
    }

    //Prevent player from double jumping
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    //Move player based on WASD input
    void MovePlayer()
    {
        //Get direction of the input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);

        //Check if right mouse button is pressed
        bool isRotating = Input.GetMouseButtonDown(1);

        //Rotate input direction to camera's forward direction if right mouse button is pressed
        if (isRotating)
        {
            //Get direction of the camera's forward vector in the xz plane
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            //Calculate the new direction by rotating the input direction to the camera
            Quaternion rotation = Quaternion.LookRotation(cameraForward);
            Vector3 direction = rotation * inputDirection;
        }

        //Move player in the new direction
        transform.Translate(inputDirection * Time.deltaTime * speed);
    }
} 


