using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public float fillSpeed = 0.5f;
    public Text scoreText;
    public Text levelText;

    public Score Score;

    private Slider slider;
    private ParticleSystem particles;
    private float targetXP; // = 0f;
    private float remainingXP;
    private float currentScore = 0;
    private int playerLevel = 1;
    private float xpToNextLevel = 100f;
    private float currentTotalXp;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particles = GameObject.Find("XpParticles").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        Score = new Score(currentScore, targetXP, slider);
        Score.IncrementScoreAndXP(150);
        //IncrementScoreAndXP(240);
    }

    private void LateUpdate()
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
            scoreText.text = PlayerPrefs.GetFloat("playerScore") + ""; // + "            " + playerLevel + " lvl";
            levelText.text = playerLevel + "";
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

    //public void IncrementScoreAndXP(float newScore)
    //{
    //    currentScore = currentScore + newScore;
    //    PlayerPrefs.SetFloat("playerScore", currentScore);

    //    targetXP = slider.value + newScore / 100;
    //}
}

public class Score
{
    float currentScore;
    float targetXP;
    Slider slider;

    public Score(float _currentScore, float _targetXP, Slider _slider)
    {
        this.currentScore = _currentScore;
        this.targetXP = _targetXP;
        this.slider = _slider;
    }

    public void IncrementScoreAndXP(float newScore)
    {
        currentScore = currentScore + newScore;
        PlayerPrefs.SetFloat("playerScore", currentScore);

        targetXP = slider.value + newScore / 100;
    }
}
