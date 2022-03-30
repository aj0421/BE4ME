using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public float fillSpeed = 0.5f;

    private Slider slider;
    private ParticleSystem particles;
    private float targetXP = 0f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particles = GameObject.Find("XpParticles").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        IncrementXP(2.40f);
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
    }

    public void IncrementXP(float newXP)
    {
        targetXP = slider.value + newXP;
    }
}
