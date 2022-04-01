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
    private List<string> temp;
    private GameObject[] characterArray;

    public List<string> year;

    public string storedValue;
    private GameObject characterManager;
    private GameObject character;
    int index = 0;
    #endregion


    #region Method
    public void Start()
    {
        Initialize();
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
        dropdown = GetComponent<Dropdown>();
        options = new List<string>();
        year = new List<string>();
        foreach (var item in characterArray)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            year.Add(yearFromCharacter.ToString());
        }
        dropdown.ClearOptions();
         Select(dropdown);
        dropdown.AddOptions(options);
        Debug.Log("YearUI : Start: The options " + year);
    }

    private void Select(Dropdown target)
    {
        for (int i = 0; i < year.Count; i++)
        {
            bool isCompleted = characterManager.gameObject.GetComponent<CharacterManager>().isCompleted;
            if (!isCompleted)
            {
                options.Add(year[i]);
                Debug.Log("Added year: " + options[i].ToString());
                return;
            }
            else
            {
                i++;
                options.Add(year[i]);
                return;
              
            }
        }
    }
    
    
    private void ValueChangeHandler(Dropdown target)
    {
        storedValue = target.options[target.value].text;
        characterManager.gameObject.GetComponent<CharacterManager>().storedValue = storedValue;
        Debug.Log("YearUI: ValueChangeHandler : stored value: " + storedValue);
    }

    #endregion
}
