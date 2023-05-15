using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Total time in seconds
    private float timeRemaining;   // Time remaining in seconds

    public GameObject gameController;
    private bool isGameOver;

    private Text timerText;        // Reference to the Text UI element

    void Start()
    {
        timerText = GetComponent<Text>();
        timeRemaining = totalTime;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0 && !isGameOver)
        {
            isGameOver = true;
            gameController.SendMessage("GameOver");
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
