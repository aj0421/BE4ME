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

    public List<GameObject> characters;

    private int index;
    private bool paused;
    private Audio audio;
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
    }

    public void Play()
    {
        for (int i = 0; i < audioList.Length; i++)
        {
            index = i;
            audio = audioList[index];

            if(audio.source != null)
            {
                audio.source.Play();
                paused = false;
            }
        }
        Debug.Log("index" + index);
    }

    public void Pause()
    {
        audio = audioList[index];
        if (audio.source.isPlaying && audio.source != null)
        {
            audio.source.Pause();
            Debug.Log("WE HAVE PAUSED");
        }
        else
        {
            Debug.Log("audio null");
        }
    }

    public void Repeat()
    {
        Audio audio = audioList[index];
        audio.source.time = 0;
        audio.source.Play();
    }
    #endregion
}
