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

    [SerializeField]
    private Button quizButton; 
    
    [SerializeField]
    private Button repeatButton;

    public List<GameObject> characters;

    private int index;
    private Audio audio;
    private bool isActive;
    #endregion

    #region Method
    private void Start()
    {
        isActive = false;
        foreach (Audio a in audioList)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
        }
    }

    public void Update()
    {
        if (isActive == true)
        {
            SpawnButton(audio);
        }
    }
    public void SpawnButton(Audio a)
    {
        if (a.source.isPlaying == false)
        {
            quizButton.gameObject.SetActive(true);
            repeatButton.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        for (int i = 0; i < audioList.Length; i++)
        {
            index = i;
            audio = audioList[index];

            if (audio.source != null)
            {
                audio.source.Play();
                isActive = true;
            }
        }
        Debug.Log("index" + index);
        SpawnButton(audio);
    }

    public void Pause()
    {
        audio = audioList[index];
        if (audio.source.isPlaying && audio.source != null)
        {
            audio.source.Pause();
            Debug.Log("WE HAVE PAUSED");
            isActive = false;
        }
        else
        {
            Debug.Log("audio null");
        }
    }

    public void Repeat()
    {
        audio = audioList[index];
        audio.source.time = 0;
        audio.source.Play();
    }
    #endregion
}
