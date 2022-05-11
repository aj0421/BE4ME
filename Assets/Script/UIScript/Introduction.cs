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
    #endregion
   
    #region Methods
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

                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
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

                //////Mouse DEBUG PURPOSE
                //if (Input.GetMouseButtonDown(0))
                //{
                //    isTouching = true;
                //}

                //if (isTouching)
                //{
                //    if (index > allTexts.Count - 1)
                //    {
                //        this.gameObject.SetActive(false);
                //    }
                //    else
                //    {
                //        introductionText.text = allTexts[index];
                //        index++;
                //        isTouching = false;
                //    }

                //}
            }
        }
    }

    #region IntroductionText
    private void AddTextPartsToListSwedish()
    {
        string part0 = "Tryck på skärmen för att påbörja";
        allTexts.Add(part0);

        string part1 = "Hej " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Nu ska du få lära dig lite historia om Helsingborg.";
        allTexts.Add(part2);

        string part3 = "En kvinna som heter <b>Maria Zoegas</b> kommer att berätta men du får hitta henne först.";
        allTexts.Add(part3);

        string part4 = "Hon dog tyvärr för många år sen, men vi har skapat en tidsmaskin som du kan använda.";
        allTexts.Add(part4);

        string part5 = "Vi har ställt tidsmaskinen här på lekplatsen. Hittar du den, kan du resa bak i tiden för att prata med henne.";
        allTexts.Add(part5);

        string part6 = "Tidsmaskinen syns på kartan, gå nära för att använda den.";
        allTexts.Add(part6);  
        
        string part7 = "Lycka till!";
        allTexts.Add(part7);
    }

    private void AddTextPartsToListEnglish()
    {
        string part0 = "Tap on the screen to begin.";
        allTexts.Add(part0);

        string part1 = "Hi " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Now you will learn some history about Helsingborg ";
        allTexts.Add(part2);

        string part3 = "A woman by the name <b>Maria Zoegas</b> will tell you about it, but you will have to find her first.";
        allTexts.Add(part3);

        string part4 = "Unfortunately, she died many years ago, but we have created a time machine that you can use.";
        allTexts.Add(part4);

        string part5 = "We've placed the time machine here in the playground. If you find it, you can travel back in time to talk to her.";
        allTexts.Add(part5);

        string part6 = "The time machine appears on the map, go near it to use it.";
        allTexts.Add(part6);
        
        string part7 = "Good luck!";
        allTexts.Add(part7);
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
