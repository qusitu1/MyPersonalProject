using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Player collided with an enemy
            Debug.Log("Player collided with an enemy");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
        }
    }
}
