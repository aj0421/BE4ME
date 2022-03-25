using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearUI : MonoBehaviour
{
    public Dropdown dropdown;

    public List<string> year;
    private List<string> options;

    private GameObject[] characterArray;

    public void Start()
    {
        var characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characterArray = characterManager.gameObject.GetComponent<CharacterManager>().characterArray;
        dropdown = GetComponent<Dropdown>();
        options = new List<string>();
        year = new List<string>();
        foreach (var item in characterArray)
        {
            var temp = item.GetComponent<Character>().year;
            year.Add(temp.ToString());
            Debug.Log("YearUI : Start: Adding year to a list: " + year.Count);
        }

        for (int i = 0; i < year.Count; i++)
        {
            //options.Add(i.ToString());
            options.Add(year[i]);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
        Debug.Log("YearUI : Start: The options " + year);
    }
}
