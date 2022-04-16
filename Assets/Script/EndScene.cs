using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Text text;

    public void Start()
    {
        string score = PlayerPrefs.GetFloat("playerScore").ToString();
        text.text = "Your score: " + score;      
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
