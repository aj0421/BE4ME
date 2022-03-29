using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public float fillSpeed = 0.5f;
    public Text scoretext;

    private Slider slider;
    private ParticleSystem particles;
    private float targetXP = 0f;
    private float remainingXP;
    private float currentScore = 0;
    private int playerLevel = 1;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particles = GameObject.Find("XpParticles").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        IncrementScoreAndXP(75);
    }

    private void Update()
    {
        if(slider.value < targetXP)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particles.isPlaying)
            {
                particles.Play();
            }
        }
        else
        {
            particles.Stop();
        }

        if(slider.value >= 1.0f)
        {
            //TODO: change the following to fill slider for the remaining part of the XP instead of 0.1f.
            slider.value = 0.1f;
            targetXP = 0.0f;  
        }

        if(scoretext != null)
        {
            scoretext.text = PlayerPrefs.GetFloat("playerScore") + " P";
        }
    }

    private void IncrementScoreAndXP(float newScore)
    {
        currentScore = currentScore + newScore;
        PlayerPrefs.SetFloat("playerScore", currentScore);

        targetXP = slider.value + newScore/100;
    }
}
