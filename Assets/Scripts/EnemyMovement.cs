using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{

    public float speed = 3;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.right * speed);
    }
}
