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
    #endregion


    #region Method
    public void Start()
    {
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characterArray = characterManager.gameObject.GetComponent<CharacterManager>().characterArray;
        dropdown = GetComponent<Dropdown>();
        options = new List<string>();
        year = new List<string>();
        foreach (var item in characterArray)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            year.Add(yearFromCharacter.ToString());
            Debug.Log("YearUI : Start: Adding year to a list: " + year.Count);
        }

        for (int i = 0; i < year.Count; i++)
        {
            options.Add(year[i]);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
        Debug.Log("YearUI : Start: The options " + year);
        ValueChangeHandler(dropdown);
        dropdown.onValueChanged.AddListener(delegate
        {
            ValueChangeHandler(dropdown);
        });
      
    }

    private void ValueChangeHandler(Dropdown target)
    {
        storedValue = target.options[target.value].text;
        characterManager.gameObject.GetComponent<CharacterManager>().storedValue = storedValue;
        Debug.Log("YearUI: ValueChangeHandler : stored value: " + storedValue);
    }

    #endregion
}
