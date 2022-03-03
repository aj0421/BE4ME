using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerClass : MonoBehaviour
{
    #region Variable
    public bool isCorrect = false;
    public QuizManager quizManager;
    #endregion

    #region Method
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.Correct();
        }
    }

    #endregion
}
