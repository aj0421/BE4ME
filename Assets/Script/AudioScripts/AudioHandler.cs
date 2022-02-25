using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private AudioSource[] audioList;

    private int numberofAudio;
    private bool play;
    private bool toggleChange;

    #endregion

    #region Method
    private void Start()
    {
        numberofAudio = audioList.Length;
        audioList[numberofAudio] = GetComponent<AudioSource>();

       //audioSource = GetComponent<AudioSource>();
        play = true;
    }

    public void Play()
    {
        if (play == true && toggleChange == true)
        {
            audioList[0].Play();
            toggleChange = false;
        }
    }
    
    public void Pause()
    {
        if (play == false && toggleChange == false)
        {
            audioList[0].Stop();

            toggleChange = false;
        }
        else
        {
            audioList[0].UnPause();
        }
    }

    public void Repeat()
    {
    
    }

    #endregion
}
