using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    #region Variables
    public GameObject[] characterArray;

    public string storedValue;

    public Text yearText;
    private static CharacterManager instance;

    public bool isCompleted;
    public bool readIntroduction;
    public List<string> answerList = new List<string>();

    #endregion

    #region Method
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (var item in characterArray)
        {
            isCompleted = item.GetComponent<Character>().isCompleted;
        }
    }

    public void ChangeYearUI()
    {
        if (yearText == null)
        {
            try
            {
                yearText = GameObject.Find("YearText").GetComponent<Text>();
            }
            catch
            {
                return;
            }
        }
        if (storedValue == "")
        {
            return;
        }
        else
        {
            yearText.text = storedValue;
      
        }
    }
    #endregion
}
