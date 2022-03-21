using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMachine : MonoBehaviour
{
    public CameraShake CameraShake;
    public Text countdownText;
    public float duration = 6.0f;
    public float magnitude = 0.3f;

    private float counter;

    public void Start()
    {
        counter = 6;

        if(CameraShake != null)
        {
            StartCoroutine(CameraShake.Shake(duration, magnitude));
        }
    }

    public void Update()
    {
        if(counter > 0)
        {
            counter -= Time.deltaTime;
            countdownText.text = "" + Mathf.Ceil(counter);
        }
        else
        {
            countdownText.text = "" + 0;
        }
    }
}
