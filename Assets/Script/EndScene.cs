using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Text text;

    public void Start()
    {          
        text.text = "Your Result: " + PlayerPrefs.GetString("SavedResult");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
