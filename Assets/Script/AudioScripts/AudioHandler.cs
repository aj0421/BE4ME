using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
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

    private GameObject parent;
    private GameObject child;

    private int index;
    private Audio audio;
    private AudioSource aSource;
    private bool isActive;
    private string language = "";
    #endregion

    #region Method
    public void Start()
    {
        isActive = false;
        foreach (Audio a in audioList)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
        }
        audio = audioList[index];
    }
    public void Update()
    {
        if (isActive == true)
        {
            SpawnButton();
        }
    }
    public void SpawnButton()
    {
        if (aSource.isPlaying == false)
        {
            quizButton.gameObject.SetActive(true);
            repeatButton.gameObject.SetActive(true);
        }
    }
    public void AddSoundEffects(GameObject button, string name)
    {
        audio.source = button.GetComponent<AudioSource>();
        aSource = audio.source;

        foreach (var item in audioList)
        {
            if (item.name == name)
            {
                aSource.clip = item.clip;
                aSource.Play();
            }
        }
    }
    public void AddAudio(GameObject button, string name)
    {
        audio.source = button.GetComponent<AudioSource>();
        aSource = audio.source;

        foreach (var item in audioList)
        {
            if (item.name == name)
            {
                aSource.clip = item.clip;
                aSource.Play();
                if (!aSource.isPlaying)
                {
                    isActive = true;
                }
            }
        }
    }
    public void Play()
    {
        CheckCharacter();
        AddSoundEffects(this.gameObject, "button_tap");
    }

    private void CheckCharacter()
    {
        parent = GameObject.FindGameObjectWithTag("CharacterParent");
        child = parent.transform.GetChild(0).gameObject;
        language = LocalizationSettings.SelectedLocale.ToString();
        if (language == "Swedish (sv)")
        {
            switch (child.GetComponent<Character>().year)
            {
                case "1885":
                    AddAudio(child, "Maria_Sv_1");
                    break;
                case "1888":
                    AddAudio(child, "Maria_Sv_2");
                    break;
                case "1900":
                    AddAudio(child, "Maria_Sv_3");
                    break;
            }
        }
        else if (language == "English (en)")
        {

            switch (child.GetComponent<Character>().year)
            {
                case "1885":
                    AddAudio(child, "frenchWoman");
                    break;
                case "1888":
                    AddAudio(child, "frenchWoman");
                    break;
                case "1900":
                    AddAudio(child, "frenchWoman");
                    break;
            }
        }

       
    }

    public void Pause()
    {
        if (aSource.isPlaying && aSource != null)
        {
            aSource.Pause();
            AddSoundEffects(this.gameObject, "button_tap");
            isActive = false;
        }
        else
        {
            Debug.Log("audio null");
        }
    }

    public void Repeat()
    {
        aSource.time = 0;
        aSource.Play();
        AddSoundEffects(this.gameObject, "button_tap");
    }
    #endregion
}
