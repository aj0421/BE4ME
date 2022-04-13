using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    #region Variables
    public float fillSpeed = 0.5f;
    public Text scoreText;
    public Text levelText;

    private Slider slider;
    private ParticleSystem particles;
    private float targetXP; // = 0f;
    private float remainingXP;
    private float currentScore = 0;
    private int playerLevel = 1;
    private float xpToNextLevel = 100f;
    private float currentTotalXp;
    private int sceneIndex;
    private float updatedScore;
    #endregion

    #region Methods
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 1:
                slider = gameObject.GetComponent<Slider>();
                particles = GameObject.Find("XpParticles").GetComponent<ParticleSystem>();
                updatedScore = PlayerPrefs.GetFloat("updatedScore");
                if(updatedScore > 0)
                {
                    Debug.Log("The new score from quiz = " + updatedScore);
                    IncrementScoreAndXP(updatedScore);
                }
                //IncrementScoreAndXP(60);
                break;
            case 2:
                //IncrementScoreAndXP(20);
                break;

        }
    }

    private void LateUpdate()
    {
        if(sceneIndex == 1)
        {
            if (slider.value < targetXP)
            {
                slider.value += fillSpeed * Time.deltaTime;

                while (CheckRemainingXpAndSetSliderValue())
                {
                    playerLevel++;
                }

                if (!particles.isPlaying)
                {
                    particles.Play();
                }
            }
            else
            {
                particles.Stop();
            }

            if (scoreText != null)
            {
                scoreText.text = PlayerPrefs.GetFloat("playerScore") + "";
                levelText.text = playerLevel + "";
            }
        }
    }

    private bool CheckRemainingXpAndSetSliderValue()
    {
        if (targetXP > (currentTotalXp / 100) && slider.value >= 1)
        {
            remainingXP = 1.0f - targetXP;
            slider.value = 0.0f;
            targetXP = remainingXP * -1;
            currentTotalXp = currentTotalXp - xpToNextLevel;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncrementScoreAndXP(float newScore)
    {
        currentScore = currentScore + newScore;
        PlayerPrefs.SetFloat("playerScore", currentScore);
        targetXP = slider.value + newScore / 100;
    }
    #endregion
}
