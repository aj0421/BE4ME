using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    public CameraShake CameraShake;
    public float duration = 5f;
    public float magnitude = 0.3f;

    public void Start()
    {
        if(CameraShake != null)
        {
            Debug.Log("CameraShake Start: Start is being called.");
            StartCoroutine(CameraShake.Shake(duration, magnitude));
        }
    }
}
