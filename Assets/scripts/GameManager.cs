using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] TextMeshProUGUI highestScore;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Main Menu Scene
            print("Main menu scene");
            highestScore.text = "High Score: " + PlayerPrefs.GetFloat("score", 0f).ToString("F2");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Example()
    {
        print("Test");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
