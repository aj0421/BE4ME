using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public Text introductionText;
    public Text playerName;
    public GameObject guideScore;
    public Image clickIndicator;

    private List<string> allTexts;
    private bool previousWasTouching = false;
    private bool isTouching = false;
    private int index = 1;
    private string language;

    private void Awake()
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

    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            StartCoroutine(ClickFading(true));

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

        string part2 = "Nu ska du få lära dig historien om en känd kvinna från helsingborg vid namn <b>Maria Zoegas</b>";
        allTexts.Add(part2);

        string part3 = "Men spelet kommer inte berätta om henne, utan du får själv hitta henne.";
        allTexts.Add(part3);

        string part4 = "Hon dog tyvärr för många år sen, men vi har skapat en tidsmaskin som du kan använda.";
        allTexts.Add(part4);

        string part5 = "Vi har ställd tidsmaskinen här på lekplatsen. Hittar du den, kan du resa bak i tiden för att prata med henne.";
        allTexts.Add(part5);

        string part6 = "Lycka till!";
        allTexts.Add(part6);
    }

    private void AddTextPartsToListEnglish()
    {
        string part1 = "Hi " + PlayerPrefs.GetString("name") + " !";
        allTexts.Add(part1);

        string part2 = "Now you will learn the story of a famous woman from Helsingborg named <b>Maria Zoegas</b>";
        allTexts.Add(part2);

        string part3 = "But the game won't tell you about her, you'll have to find her yourself.";
        allTexts.Add(part3);

        string part4 = "Unfortunately, she died many years ago, but we have created a time machine that you can use.";
        allTexts.Add(part4);

        string part5 = "We've placed the time machine here in the playground. If you find it, you can travel back in time to talk to her.";
        allTexts.Add(part5);

        string part6 = "Good luck!";
        allTexts.Add(part6);
    }

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
}
