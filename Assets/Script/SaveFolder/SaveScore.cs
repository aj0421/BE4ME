using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveScore : MonoBehaviour
{

    #region Variables
    string score;
    string nae;

    #endregion

    #region Methods
    private Save CreateSave()
    {
        Save save = new Save();
        save.name = PlayerPrefs.GetString("name");
        save.score = PlayerPrefs.GetFloat("playerScore").ToString();

        //name = save.name;
        //score = save.score;        //name = save.name;
        //score = save.score;
        //save.scoreTable.Add(name, score);

        return save;

    }

    public void SaveFile()
    {
        Save save = CreateSave(); // Create a Save instance with all the data for the current session saved into it
        string path = Application.persistentDataPath + "/score.txt";
        // Serialize the data and writes it to the phone
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Save " + file.Name);

        save.name = "";
        save.score = "";
        //save.scoreTable.Clear();
    }

    #endregion
}

