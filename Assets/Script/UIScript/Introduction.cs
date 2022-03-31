using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public Text introductionText;
    public Text playerName;
    public GameObject guideScore;

    private List<string> allTexts;
    private bool previousWasTouching = false;
    private bool isTouching = false;
    private int index = 1;
    private bool isSwedish;
    private string selectedLanguage = "swedish"; //default

    private void Awake()
    {
        allTexts = new List<string>();
        selectedLanguage = PlayerPrefs.GetString("language");
        if (selectedLanguage == "swedish")
        {
            AddTextPartsToListSwedish();
        }
        else if (selectedLanguage == "english")
        {
            AddTextPartsToListEnglish();
        }

        introductionText.text = allTexts[0];
        Debug.Log("alltext count: " + allTexts.Count + " 1: " + allTexts[0]);
    }

    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            //isTouching = Input.touchCount > 0;

            //if (isTouching && !previousWasTouching && index > allTexts.Count -1)
            //{
            //    this.gameObject.SetActive(false);
            //}
            //else
            //{
            //    introductionText.text = allTexts[index];
            //    index++;
            //    previousWasTouching = isTouching;
            //}

            //isTouching = Input.touchCount > 0;
            //if (isTouching && !previousWasTouching)
            //{
            //    for (index = 0; index < allTexts.Count; index++)
            //    {
            //        introductionText.text = allTexts[index];
            //        previousWasTouching = isTouching;
            //    }
            //}

            //Mouse

            if (Input.GetMouseButtonDown(0))
            {
                isTouching = true;
            }

            if (isTouching)
            {
                if (index > allTexts.Count - 1)
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    introductionText.text = allTexts[index];
                    index++;
                    isTouching = false;
                }

            }
        }
    }

    private void AddTextPartsToListSwedish()
    {
        string part1 = "Hej " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Nu ska du f� l�ra dig om historien om en k�nd kvinna fr�n helsingborg vid namn Maria Zoegas";
        allTexts.Add(part2);

        string part3 = "Men det �r inte spelet som kommer ber�tta det utan du f�r sj�lv hitta henne.";
        allTexts.Add(part3);

        string part4 = "Hon dog f�r flera �r sen, men vi har skapat en tidsmaskin som du har till�telse att anv�nda.";
        allTexts.Add(part4);

        string part5 = "Vi har placerat tidsmaskinen h�r p� lekplatsen. Hittar du den kan du resa bak i tiden f�r att prata med henne.";
        allTexts.Add(part5);

        string part6 = "Vi har en nyckel som du beh�ver f�r att anv�nda den";
        allTexts.Add(part6);

        string part7 = "Om du �r os�ker p� n�got p� sk�rmen, tryck p� fr�getecknet.";
        allTexts.Add(part7);
    }

    private void AddTextPartsToListEnglish()
    {
        string part1 = "Hi " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "one";
        allTexts.Add(part2);

        string part3 = "two";
        allTexts.Add(part3);

        string part4 = "three";
        allTexts.Add(part4);

        string part5 = "four";
        allTexts.Add(part5);
    }
}
