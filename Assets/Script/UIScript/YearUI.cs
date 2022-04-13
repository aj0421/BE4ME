using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearUI : MonoBehaviour
{
    #region Variable
    public List<string> year;
    public Text yearText;
    public string storedValue = "";
    public GameObject characterManager;

    [SerializeField]
    private Dropdown dropdown;

    private List<string> options;
    private GameObject[] characterArray;
    private GameObject character;
    private int index = 0;

    private bool isCompleted;
    #endregion

    #region Method
    public void Start()
    {
        dropdown = GetComponent<Dropdown>();

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
        options = new List<string>();
        year = new List<string>();

        foreach (var item in characterArray)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            year.Add(yearFromCharacter.ToString());
        }
        Select();
    }

    private void OnEnable()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characterArray = characterManager.gameObject.GetComponent<CharacterManager>().characterArray;
        isCompleted = characterManager.gameObject.GetComponent<CharacterManager>().isCompleted;
    }

    private void OnDisable()
    {
        characterManager.gameObject.GetComponent<CharacterManager>().isCompleted = false;
    }

    private void Select()
    {
        switch (yearText.text)
        {
            case "2022":
                AddOptionsToDropdown(year[0]);
                break;
            case "1880":
                if (isCompleted)
                {
                    AddOptionsToDropdown(year[0]);
                    AddOptionsToDropdown(year[1]);
                }
                else
                {
                    AddOptionsToDropdown(year[0]);
                }
                break;
            case "1996":
                if (isCompleted)
                {
                    AddOptionsToDropdown(year[0]);
                    AddOptionsToDropdown(year[1]);
                    AddOptionsToDropdown(year[2]);
                }
                else
                {
                    AddOptionsToDropdown(year[0]);
                    AddOptionsToDropdown(year[1]);
                }
                break;
            case "1969":
                if (isCompleted)
                {
                    AddOptionsToDropdown(year[0]);
                    AddOptionsToDropdown(year[1]);
                    AddOptionsToDropdown(year[2]);
                }
                else
                {
                    AddOptionsToDropdown(year[0]);
                    AddOptionsToDropdown(year[1]);
                    AddOptionsToDropdown(year[2]);
                }
                break;
        }
    }

    private void AddOptionsToDropdown(string _year)
    {
        options.Add(_year);
        dropdown.AddOptions(options);
        options.Clear();
    }

    private void ValueChangeHandler(Dropdown target)
    {
        storedValue = target.options[target.value].text;
        characterManager.gameObject.GetComponent<CharacterManager>().storedValue = storedValue;
    }

    #endregion
}
