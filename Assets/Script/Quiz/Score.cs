using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region Variables

    public Text scoretext;

    private int currentScore = 0;
    private bool scoreIsUpdated = false;

    #endregion

    #region Methods

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            if(scoretext != null)
            {
                scoretext.text = PlayerPrefs.GetInt("player_score") + " P";
            }
            else
            {
                Debug.LogError("ScoreText is null, check the inspector. Otherwise the Score-Script is adressing the wrong scene number in OnLevelWasLoaded !");
            }
        }
    }

    private void Update()
    {
        if (scoretext != null && scoreIsUpdated)
        {
            scoretext.text = PlayerPrefs.GetInt("player_score") + " P";
            scoreIsUpdated = false;
        }
        else
        {
            Debug.LogError("Either scoreText is null or you need to check to playerPrefs");
        }
    }

    public void IncrementScore(int newScore)
    {
        currentScore = currentScore + newScore;
        PlayerPrefs.SetInt("player_score", currentScore);
        scoreIsUpdated = true;
    }

    #endregion
}
