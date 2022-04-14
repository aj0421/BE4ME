using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    #region Methods
    private GameObject characterManager;

    public static SaveScore Instance;

    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
    }

    private Save CreateSave(string path)
    {
        Save save = new Save();
        save.name = PlayerPrefs.GetString("name");
        save.score = PlayerPrefs.GetFloat("playerScore").ToString();
        List<string> temp = characterManager.GetComponent<CharacterManager>().answerList;
        save.allSavedData.Add(save.name);
        save.allSavedData.Add(save.score);
        for (int i = 0; i < temp.Count; i++)
        {
            save.allSavedData.Add(temp[i]);
        }
        File.WriteAllLines(path, save.allSavedData);
        return save;
    }

    public void SaveFile()
    {
        string path = Application.persistentDataPath + "/score.txt";
        Save save = CreateSave(path); // Create a Save instance with all the data for the current session saved into it  
                                      // Serialize the data and writes it to the phone
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path + "/n");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Save " + file.Name);

        save.name = "";
        save.score = "";
        save.allSavedData.Clear();
    }
    #endregion
}

