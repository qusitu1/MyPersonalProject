using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITimeDisplay : MonoBehaviour
{
    public TimeLimitController timeLimitController;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = timeLimitController.currentTime;
        timeText.text = "Time: " + currentTime.ToString("F1");
    }
}
