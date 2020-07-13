using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;
    public Text ScoreText;
    int Score = 0;
    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void AddScore(int Increment)
    {
        Score += Increment;
    }
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        ScoreText.text = $"{Score} Points";
    }
}
