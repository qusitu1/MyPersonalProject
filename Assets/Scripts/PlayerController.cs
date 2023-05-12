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
        //Keep player in bounds
        if(transform.position.x < -180)
        {
            transform.position = new Vector3(-180, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 180)
        {
            transform.position = new Vector3(180, transform.position.y, transform.position.z);
        }

        if(transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
        if(transform.position.z > 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 40);
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        //Reset input values if no keys are being pressed
        if (!Input.anyKey)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
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
        //Get direction of the camera's forward vector in the xz plane
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward = cameraForward.normalized;

        //Get direction of the input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Only move the player if there is input from the user
        if (horizontalInput != 0 || verticalInput != 0)
        {
            //Calculate the new direction by rotating the input direction to the camera
            Vector3 direction = Quaternion.Euler(0f, Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg, 0f) * cameraForward;
        

            //Move player in the new direction
            transform.Translate(direction * Time.deltaTime * speed, Space.World); 
        }

        

        
    }
} 


