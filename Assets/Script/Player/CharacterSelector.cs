using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public Text nametext;  //TODO: This is currently set to the placeholder text, change it to whatever the player enters.
    //public Button swedishButton;
    //public Button englishButton;

    [SerializeField]
    private int currentCharacter = 0;

    private string name;
    private bool englishIsClicked = false;
    private bool swedishIsClicked = false;

    private void Start()
    {
        //swedishButton.onClick.AddListener(ButtonClickSwedish);
        //englishButton.onClick.AddListener(ButtonClickEnglish);
    }

    public void SaveSelected()
    {
        name = nametext.text;
        PlayerPrefs.SetInt("selectedCharacter", currentCharacter);
        PlayerPrefs.SetString("name", nametext.text);
        //PlayerPrefs.SetString("language", SelectedLanguage());
    }

    private string SelectedLanguage()
    {
        if (swedishIsClicked)
        {
            return "swedish";
        }
        else
        {
            return "english";
        }
    }

    private void ButtonClickSwedish()
    {
        swedishIsClicked = true;
        englishIsClicked = false;
    }

    private void ButtonClickEnglish()
    {
        englishIsClicked = true;
        swedishIsClicked = false;
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
