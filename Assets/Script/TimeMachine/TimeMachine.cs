using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeMachine : MonoBehaviour
{
    public CameraShake CameraShake;
    public UIManager UIManager;
    public Text countdownText;
    public float duration = 6.0f;
    public float magnitude = 0.3f;

    private float counter;
    private bool isBlackedOut = false;
    private GameObject audioHandler;

    public void Start()
    {
        audioHandler = GameObject.Find("AudioHandler");
      
        counter = 6;

        if(CameraShake != null)
        {
            Vibration.Vibrate(3000);
            StartCoroutine(CameraShake.Shake(duration, magnitude));
            audioHandler.GetComponent<AudioHandler>().AddSoundEffects(this.gameObject, "timetravel");
        }
      
    }

    public void Update()
    {
      
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            countdownText.text = "" + Mathf.Ceil(counter);
           
        }
        else
        {
            countdownText.text = "" + 0;
        }

        if(counter < 0.2 && isBlackedOut == false)
        {
            StartCoroutine(UIManager.GetComponent<UIManager>().FadeToBlack());
            isBlackedOut = true;
        }
        if (isBlackedOut)
        {
            SceneManager.LoadScene(1);
        }
    }
}
