using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    #region Variables
    public GameObject[] characterArray;

    public string storedValue;

    public Text text;
    private static CharacterManager instance;

    public bool isCompleted;
    #endregion

    #region Method
    private void Awake()
    {
        foreach (var item in characterArray)
        {
            isCompleted = item.GetComponent<Character>().isCompleted;
        }
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeYearUI()
    {
        if (text == null)
        {
            try
            {
                text = GameObject.Find("YearText").GetComponent<Text>();

            }
            catch
            {
                return;
            }
        }
        else if (storedValue == "")
        {
            return;
        }
        else
        {
            text.text = storedValue;
        }
    }
    #endregion
}
