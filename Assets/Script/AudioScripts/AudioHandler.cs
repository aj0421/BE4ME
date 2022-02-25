using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private Audio[] audioList;

    #endregion

    #region Method
    private void Start()
    {
        foreach (Audio a in audioList)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;

            a.source.volume = a.volume;
        }
        //audioSource = GetComponent<AudioSource>();
       
    }

    public void Play(string name)
    {
        Audio audio = Array.Find(audioList, a => a.name == name);
        if(audio == null)
        {
            Debug.Log("did not find array");
            return;
        }
        else
        {
            audio.source.Play();
        }
    }

    public void Pause()
    {
       

    }

    public void Repeat()
    {

    }

    #endregion
}
