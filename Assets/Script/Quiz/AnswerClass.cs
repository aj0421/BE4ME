using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerClass : MonoBehaviour
{
    #region Variable
    public bool isCorrect = false;
    public GameObject quizManager;
    public CharacterManager characterManager;

    [HideInInspector]
    public GameObject currentCharacter;
    #endregion

    #region Method

    public void Start()
    {
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
    }
    public void Update()
    {
        foreach (GameObject character in characterManager.characterArray)
        {
            if (character.activeInHierarchy)
            {
                currentCharacter = character;
            }
            else
            {
                Debug.Log("Waiting for character to Spawn... (Log from AnswerClass)");
            }
        }
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            StartCoroutine(VisualTimer(new Color(46, 204, 113, 1)));

            quizManager.GetComponent<QuizManager>().Correct();
            gameObject.GetComponent<Image>().color = new Color(37, 41, 88, 1);    //Dark blue
        }
        else
        {
            Debug.Log("Wrong Answer");
            StartCoroutine(VisualTimer(new Color(255, 0, 0, 1)));

            quizManager.GetComponent<QuizManager>().Correct();
            gameObject.GetComponent<Image>().color = new Color(37, 41, 88, 1);    //Dark blue
        }
    }

    public IEnumerator VisualTimer(Color buttonColor)
    {
        float waitDuration = 1.2f;
        float normalized = 0;
        while(normalized <= 1f)
        {
            gameObject.GetComponent<Image>().color = buttonColor;
            normalized += Time.deltaTime / waitDuration;
            yield return null;
        }
    }

    #endregion
}
