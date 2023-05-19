using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitController : MonoBehaviour
{
    public float totalTime = 60f;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            EndGame();
        }
    }
      void EndGame()
    {
        // Perform game-ending actions here, such as showing the game over screen
        Debug.Log("Game Over!");
    }
}
