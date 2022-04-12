using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerClass : MonoBehaviour
{
    #region Variable
    public bool isCorrect = false;
    public GameObject quizManager;

    [HideInInspector]
    public GameObject currentCharacter;

    public GameObject characterParent;

    private GameObject characterManager;
    private int score;

    private GameObject audio;
    private float storedScore;
    #endregion

    #region Method

    public void Start()
    {

        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        storedScore = PlayerPrefs.GetFloat("playerScore");
        audio = GameObject.Find("AudioHandler");
    }

    private int CalculateNewScore(int newScore)
    {
        score += newScore;
        return score;
    }

    public void GetAnswer(Text answer)
    {
        characterManager.GetComponent<CharacterManager>().answerList.Add(answer.text);
    }

    public void Answer()
    {
        if (isCorrect)
        {
            StartCoroutine(VisualTimer(new Color(255, 0, 150, 1), new Color(37, 41, 88, 1)));
            audio.GetComponent<AudioHandler>().AddSoundEffects(this.gameObject, "correct");
            storedScore += CalculateNewScore(50);
            PlayerPrefs.SetFloat("updatedScore", storedScore);
        }
        else
        {
            StartCoroutine(VisualTimer(new Color(255, 0, 0, 1), new Color(37, 41, 88, 1)));
            audio.GetComponent<AudioHandler>().AddSoundEffects(this.gameObject, "wrong");
            storedScore += CalculateNewScore(10);
            PlayerPrefs.SetFloat("updatedScore", storedScore);
        }
    }

    public IEnumerator VisualTimer(Color buttonColor, Color buttonColorNormal)
    {
        float waitDuration = 1.2f;
        float normalized = 0;
        while(normalized <= 1f)
        {
            gameObject.GetComponent<Image>().color = buttonColor;
            normalized += Time.deltaTime / waitDuration;

            yield return null;
        }
        quizManager.GetComponent<QuizManager>().Correct();
        gameObject.GetComponent<Image>().color = buttonColorNormal;    //Dark blue
    }
    #endregion
}
