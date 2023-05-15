using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ThelostChildText;
    public Button startButton;
    public GameObject titleScreen;
    public bool isGameActive;
    public bool gameStarted = false;

    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnStartButtonClicked()
    {
        ThelostChildText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        isGameActive = true;

        //Start camera movement
        cameraController.isMoving = true;
    }

}
