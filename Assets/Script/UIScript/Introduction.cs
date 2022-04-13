using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    #region Variables


    public Text introductionText;
    public Text playerName;
    public GameObject guideScore;
    public Image clickIndicator;
    private List<string> allTexts;
    private bool isTouching = false;
    private int index = 1;
    private string language = "";
    GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("CharacterManager");
        if (!gameManager.GetComponent<CharacterManager>().readIntroduction)
        {
            allTexts = new List<string>();
            language = LocalizationSettings.SelectedLocale.ToString();
            if (language == "Swedish (sv)")
            {
                AddTextPartsToListSwedish();
            }
            else if (language == "English (en)")
            {
                AddTextPartsToListEnglish();
            }
            else
            {
                AddTextPartsToListEnglish();  //Default
            }

            introductionText.text = allTexts[0];
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

    }

    private void Update()
    {
        if (index > allTexts.Count - 1)
        {
            gameManager.GetComponent<CharacterManager>().readIntroduction = true;
            Destroy(this.gameObject);
        }
        else
        {
            if (this.gameObject.activeInHierarchy)
            {
                StartCoroutine(ClickFading(true));

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Ended)
                    {
                        if (index > allTexts.Count - 1)
                        {
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            introductionText.text = allTexts[index];
                            index++;
                        }
                    }
                }

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
    }

    #region IntroductionText
    private void AddTextPartsToListSwedish()
    {
        //string part1 = "Hej " + PlayerPrefs.GetString("name") + " !";
        //allTexts.Add(part1);

        //string part2 = "Nu ska du f� l�ra dig historien om en k�nd kvinna fr�n helsingborg vid namn <b>Maria Zoegas</b>";
        //allTexts.Add(part2);

        //string part3 = "Men spelet kommer inte ber�tta om henne, utan du f�r sj�lv hitta henne.";
        //allTexts.Add(part3);

        //string part4 = "Hon dog tyv�rr f�r m�nga �r sen, men vi har skapat en tidsmaskin som du kan anv�nda.";
        //allTexts.Add(part4);

        //string part5 = "Vi har st�lld tidsmaskinen h�r p� lekplatsen. Hittar du den, kan du resa bak i tiden f�r att prata med henne.";
        //allTexts.Add(part5);

        //string part6 = "Lycka till!";
        //allTexts.Add(part6);
        string part1 = "Hej " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Nu ska du f� resa i tiden och samla stj�rnor!";
        allTexts.Add(part2);

        string part3 = "Vi har st�llt en tidsmaskin h�r p� lekplatsen.";
        allTexts.Add(part3);

        string part4 = "Varje �r du �ker till, finns det en tjej som kommer st�lla lite fr�gor.";
        allTexts.Add(part4);

        string part5 = "Svarar du r�tt p� fr�gorna, f�r du flera stj�rnor och levlar upp!";
        allTexts.Add(part5);

        string part7 = "Du ska �ka till totalt 3 olika �r.";
        allTexts.Add(part7);

        string part6 = "Lycka till!";
        allTexts.Add(part6);
    }

    private void AddTextPartsToListEnglish()
    {
        //string part1 = "Hi " + PlayerPrefs.GetString("name") + " !";
        //allTexts.Add(part1);

        //string part2 = "Now you will learn the story of a famous woman from Helsingborg named <b>Maria Zoegas</b>";
        //allTexts.Add(part2);

        //string part3 = "But the game won't tell you about her, you'll have to find her yourself.";
        //allTexts.Add(part3);

        //string part4 = "Unfortunately, she died many years ago, but we have created a time machine that you can use.";
        //allTexts.Add(part4);

        //string part5 = "We've placed the time machine here in the playground. If you find it, you can travel back in time to talk to her.";
        //allTexts.Add(part5);

        //string part6 = "Good luck!";
        //allTexts.Add(part6);

        string part1 = "Hi " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Now you will travel in time and collect stars!";
        allTexts.Add(part2);

        string part3 = "We've set up a time machine here on the playground.";
        allTexts.Add(part3);

        string part4 = "Every year you go to, there's a girl who's going to ask you some questions.";
        allTexts.Add(part4);

        string part5 = "If you answer the questions correctly, you get more stars and level up!";
        allTexts.Add(part5);

        string part7 = "You will go to a total of 3 different years.";
        allTexts.Add(part7);

        string part6 = "Good luck!";
        allTexts.Add(part6);

    }
    #endregion

    private IEnumerator ClickFading(bool fadeMinus)
    {
        if (fadeMinus)
        {
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                clickIndicator.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                clickIndicator.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
    #endregion
}
