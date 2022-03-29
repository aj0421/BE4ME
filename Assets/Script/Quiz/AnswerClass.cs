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
    #endregion

    #region Method

    public void Start()
    {

        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
    }
    public void Update()
    {
       
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.GetComponent<QuizManager>().Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.GetComponent<QuizManager>().Correct();
        }
    }

    #endregion
}
