using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public Text nametext;

    [SerializeField]
    private int currentCharacter = 0;

    private string name;

    public void SaveSelected()
    {
        name = nametext.text;
        PlayerPrefs.SetInt("selectedCharacter", currentCharacter);
        PlayerPrefs.SetString("name", nametext.text);
    }

    /// <summary>
    /// The current character will be inactivated.
    /// Then increses the currentCharacter index by 1 and mods it according to the number of characters - to make them cycleable.
    /// Then sets the new currentCharacter to active.
    /// </summary>
    public void SelectNextCharacter()
    {
        characters[currentCharacter].SetActive(false);
        currentCharacter = (currentCharacter + 1) % characters.Length;
        characters[currentCharacter].SetActive(true);
    }

    public void SelectPreviousCharacter()
    {
        characters[currentCharacter].SetActive(false);
        currentCharacter--;

        if(currentCharacter < 0)
        {
            currentCharacter += characters.Length;
        }
        characters[currentCharacter].SetActive(true);
    }
}
