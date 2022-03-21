using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerClass : MonoBehaviour
{
    #region Variable
    public bool isCorrect = false;
    public QuizManager quizManager;
    public CharacterManager characterManager;

    [HideInInspector]
    public GameObject currentCharacter;
    #endregion

    #region Method
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
