using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpawnPoint : MonoBehaviour
{
    public string identifier;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player has reached the check/spawn point
            Debug.Log("Player reached checkpoint: " + identifier);

            
        }

    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
