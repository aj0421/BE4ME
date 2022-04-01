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

    public string storedValue;
    private GameObject characterManager;
    private GameObject character;
    int index = 0;
    bool isCompleted;
    #endregion

    #region Method
    public void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
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
        options = new List<string>();
        year = new List<string>();

        foreach (var item in characterArray)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            year.Add(yearFromCharacter.ToString());
        }

        Select(); 
      // dropdown.AddOptions(options);
      
    }

    private void Select()
    {
        for (int i = 0; i < year.Count; i++)
        {
            isCompleted = characterManager.gameObject.GetComponent<CharacterManager>().isCompleted;
            if (!isCompleted)
            {
                options.Add(year[index]);
                index++;
                dropdown.AddOptions(options);
                Debug.Log("Added year: " + options[i].ToString());
                return;
            }
            else
            {
                options.Add(year[index]);
                index++;
                options.Add(year[index]);
                dropdown.AddOptions(options);
                Debug.Log("Added year: " + options[i].ToString());
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
