using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextMeshProUGUI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

public TextMeshProUGUI gameoverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.Load(SceneManager.GetActiveScene().name);
    }
}
