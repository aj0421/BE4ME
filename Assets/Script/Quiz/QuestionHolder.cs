using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class QuestionHolder
{
    private QandA QnA1;
    private QandA QnA2;
    private QandA QnA3;
    private QandA QnA4;
    private QandA QnA5;
    private QandA QnA6;

    private string language = "";

    public QuestionHolder()
    {
        language = LocalizationSettings.SelectedLocale.ToString();
    }

    public QandA Q1()
    {
        QnA1 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA1.question = "Vad var det Maria Zoega tyckte om att göra?";
            QnA1.answers = new string[]
            {
                "Rida hästar.",
                "Måla.",
                "Simma.",
                "Fotografera.",
            };
        }
        else if (language == "English (en)")
        {
            QnA1.question = "What did Maria Zoéga like to do?";
            QnA1.answers = new string[]
            {
                "Ride horses",
                "Paint",
                "Swim",
                "Take photographs",
            };
        }
        else
        {
            QnA1.question = "What did Maria Zoéga like to do?";
            QnA1.answers = new string[]
            {
                "Ride horses",
                "Paint",
                "Swim",
                "Take photographs",
            };
        }

        QnA1.correctAnswers = 4;

        return QnA1;
    }

    public QandA Q2()
    {
        QnA2 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA2.question = "Vad för slags butik ägde Carlos?";
            QnA2.answers = new string[]
            {
                "Kaffebutik.",
                "Godisbutik.",
                "Skräddare.",
                "Fotograf butik.",
            };
        }
        else if (language == "English (en)")
        {
            QnA2.question = "What kind of shop did Carlos own?";
            QnA2.answers = new string[]
            {
                "Coffee shop",
                "Candy shop",
                "Tailor shop",
                "Photograph shop",
            };
        }
        else
        {
            QnA2.question = "What kind of shop did Carlos own?";
            QnA2.answers = new string[]
            {
                "Coffee shop",
                "Candy shop",
                "Tailor shop",
                "Photograph shop",
            };
        }

        QnA2.correctAnswers = 1;

        return QnA2;
    }

    public QandA Q3()
    {
        QnA3 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA3.question = "Maria förlorade alla dessa människor under samma år: ";
            QnA3.answers = new string[]
            {
                "Hennes man, hennes son och hennes svärmor.",
                "Hennes man, hennes moster och hennes mamma.",
                "Hennes kusin och hennes vän.",
                "Hennes man och båda hennes barn.",
            };
        }
        else if (language == "English (en)")
        {
            QnA3.question = "Maria tragically lost many people in the same year. Who?";
            QnA3.answers = new string[]
            {
                "Her husband, her son and her mother-in-law.",
                "Her husband, her aunt and her mother.",
                "Her cousin and her friend.",
                "Her husband and both of her children.",
            };
        }
        else
        {
            QnA3.question = "Maria tragically lost many people in the same year. Who?";
            QnA3.answers = new string[]
            {
                "Her husband, her son and her mother-in-law.",
                "Her husband, her aunt and her mother.",
                "Her cousin and her friend.",
                "Her husband and both of her children.",
            };
        }

        QnA3.correctAnswers = 1;

        return QnA3;
    }

    public QandA Q4()
    {
        QnA4 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA4.question = "Vilket år var kriget i helsingborg?";
            QnA4.answers = new string[]
            {
                "1880",
                "1710",
                "2015",
                "1300",
            };
        }
        else if (language == "English (en)")
        {
            QnA4.question = "What year was the battle of Helsingborg?";
            QnA4.answers = new string[]
            {
                "1888",
                "1710",
                "2015",
                "1300",
            };
        }
        else
        {
            QnA4.question = "What year was the battle of Helsingborg?";
            QnA4.answers = new string[]
            {
                "1888",
                "1710",
                "2015",
                "1300",
            };
        }

        QnA4.correctAnswers = 2;

        return QnA4;
    }

    public QandA Q5()
    {
        QnA5 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA5.question = "Maria hade många sorgliga upplevelser i sitt liv, men vad tror du bäst hjälpte henne att lyckas?";
            QnA5.answers = new string[]
            {
                "Hennes rika vänner.",
                "Hennes hårda arbete och beslutsamhet",
                "Lycka och lycka.",
                "Hennes man dog.",
            };
        }
        else if (language == "English (en)")
        {
            QnA5.question = "Maria had many sad experiences in her life, but what do you think best helped her to succeed?";
            QnA5.answers = new string[]
            {
                "Her rich friends.",
                "Her hard work and determination.",
                "Happiness and luck.",
                "Her husband died.",
            };
        }
        else
        {
            QnA5.question = "Maria had many sad experiences in her life, but what do you think best helped her to succeed?";
            QnA5.answers = new string[]
            {
                "Her rich friends.",
                "Her hard work and determination.",
                "Happiness and luck.",
                "Her husband died.",
            };
        }

        QnA5.correctAnswers = 2;

        return QnA5;
    }

    public QandA Q6()
    {
        QnA6 = new QandA();
        if (language == "Swedish (sv)")
        {
            QnA6.question = "Vilken gata i Helsingborg flyttade Maria sitt företag till?";
            QnA6.answers = new string[]
            {
                "Eric Dahlbergs gata.",
                "Norra Stenbocksgatan.",
                "Drottninggatan.",
                "Knutpunkten.",
            };
        }
        else if (language == "English (en)")
        {
            QnA6.question = "What street in Helsingborg did Maria move her company to?";
            QnA6.answers = new string[]
            {
                "Eric Dahlbergsgatan",
                "Norra Stenbocksgatan.",
                "Drottninggatan.",
                "Knutpunkten.",
            };
        }
        else
        {
            QnA6.question = "What street in Helsingborg did Maria move her company to?";
            QnA6.answers = new string[]
            {
                "Eric Dahlbergsgatan",
                "Norra Stenbocksgatan.",
                "Drottninggatan.",
                "Knutpunkten.",
            };
        }

        QnA6.correctAnswers = 3;

        return QnA6;
    }
}
