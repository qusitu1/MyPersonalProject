using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject prefab;
    public float spawnDelay = 1f;

    public float spawnRangeX = 20f;
    public float spawnPosZ = -40f;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            float xPos = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPos = new Vector3(xPos, transform.position.y, transform.position.z);

            Instantiate(prefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
