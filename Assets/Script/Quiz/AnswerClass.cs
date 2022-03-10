using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerClass : MonoBehaviour
{
    #region Variable
    public bool isCorrect = false;
    public QuizManager quizManager;
    public CharacterManager characterManager;

    private GameObject currentCharacter;
    #endregion

    #region Method

    private void Awake()
    {
        for (int i = 0; i < characterManager.characterArray.Length; i++)
        {
            currentCharacter = characterManager.characterArray[i];
        }
        Debug.Log("current c: " + currentCharacter.GetComponent<Character>().characterName);
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
