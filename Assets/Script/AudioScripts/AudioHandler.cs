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

    private List<GameObject> characters;

    private int index;
    private Audio audio;
    AudioSource aSource;
    private bool isActive;
    public Text text;
    public Text play;
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
        characters = FindList("Character");
        audio = audioList[index];
    }
    private List<GameObject> FindList(string name)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (GameObject prefabToSpawn in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (prefabToSpawn.CompareTag(name))
            {
                temp.Add(prefabToSpawn);
            }
        }
        return temp;
    }

    public void Update()
    {
        if (characters == null)
        {
            characters = FindList("Character");

        }
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

    public void Play()
    {
        CheckCharacters();
        //  SpawnButton();
    }

    private void CheckCharacters()
    {
     
        for (int i = 0; i < characters.Count; i++)
        {
            play.text = audio.source.name;
            //play.text =  characters[i].GetComponent<AudioSource>().clip.name;
            //  play.text = "the count of character: " + characters[i].name;
            if (characters[i].activeInHierarchy)
            {
                play.text = "The Character is active";
                audio.source = characters[i].GetComponent<AudioSource>();
           
                aSource = audio.source;
                Debug.Log("Play: active character: " + characters[i].name);

                if (aSource != null)
                {
                    aSource.Play();
                    string test = "The sound comes from: ";
                    var tes1 = characters[i].GetComponent<AudioSource>().clip.name;
                    var tes2 = aSource.isPlaying;

                    text.text = test + tes1 + " and the audio is playing: " + tes2;
                    isActive = true;
                    Debug.Log("CheckCharacters: active audioclip: " + aSource.clip);
                }
            }
            // Debug.Log("Play: index: " + i);
        }
    }

    public void Pause()
    {
        if (aSource.isPlaying && aSource != null)
        {
            aSource.Pause();
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
        aSource.time = 0;
        aSource.Play();
    }
    #endregion
}
