using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearUI : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private Dropdown dropdown;

    private List<string> options;
    private GameObject[] characterArray;

    public List<string> year;

    public string storedValue = "";
    public GameObject characterManager;
    private GameObject character;
    int index = 0;
    bool isCompleted;
    private GameObject currentCharacter;
    #endregion

    #region Method
    public void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        Initialize();
        string setDefaultValue = characterManager.gameObject.GetComponent<CharacterManager>().storedValue;
        dropdown.value = dropdown.options.FindIndex(x => x.text == setDefaultValue);
        ValueChangeHandler(dropdown);
      
        dropdown.onValueChanged.AddListener(delegate
        {
            ValueChangeHandler(dropdown);
    
        });

    }

    private void Initialize()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characterArray = characterManager.gameObject.GetComponent<CharacterManager>().characterArray;
        options = new List<string>();
        year = new List<string>();

        foreach (var item in characterArray)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            currentCharacter = item;
            year.Add(yearFromCharacter.ToString());
        }
        Select();
        //Select2();
    }

    private void Select()
    {
        Debug.Log("year count: " + year.Count);
        for (int i = 0; i < year.Count; i++)
        {
            Debug.Log("year :" + year[i]);
            //isCompleted = characterManager.gameObject.GetComponent<CharacterManager>().isCompleted;
            //if (!isCompleted)
            //{
            //    options.Add(year[index]);
            //    index++;
            //    dropdown.AddOptions(options);
            //    Debug.Log("Added year: " + options[index].ToString());
            //    return;
            //}
            //else
            //{
            //    options.Add(year[index]);
            //    index++;
            //    options.Add(year[index]);
            //    dropdown.AddOptions(options);
            //    Debug.Log("Added year: " + options[index].ToString());
            //    return;
            //}
        }

        switch (characterManager.GetComponent<CharacterManager>().storedValue)
        {
            case "2022":
                Debug.Log(characterManager.GetComponent<CharacterManager>().yearText.text + " year text");
                AddOptionsToDropdown(year[0]);
                break;
            case "1880":
                Debug.Log(characterManager.GetComponent<CharacterManager>().yearText.text + " year text");
                AddOptionsToDropdown(year[1]);
                break;
            case "1996":
                Debug.Log(characterManager.GetComponent<CharacterManager>().yearText.text + " year text");
                AddOptionsToDropdown(year[2]);
                break;
            case "1969":
                Debug.Log(characterManager.GetComponent<CharacterManager>().yearText.text + " year text");
                break;
        }

        Debug.Log("year index 1st: " + index + " completed: " + isCompleted);

        isCompleted = characterManager.gameObject.GetComponent<CharacterManager>().isCompleted;
        AddOptionsToDropdown(year[index]);
        index++;

        if (isCompleted)
        {
            AddOptionsToDropdown(year[index]);
            Debug.Log("year options is completed: " + isCompleted);
        }
        Debug.Log("year index 2nd: " + index + " completed: " + isCompleted);
    }

    private void AddOptionsToDropdown(string _year)
    {
        options.Add(_year);
        dropdown.AddOptions(options);
    }

    private void ValueChangeHandler(Dropdown target)
    {
        storedValue = target.options[target.value].text;
        characterManager.gameObject.GetComponent<CharacterManager>().storedValue = storedValue;
    }

    #endregion
}
