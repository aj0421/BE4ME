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

    private void Awake()
    {
     
    }

    public void Update()
    {
        //for (int i = 0; i < characterManager.characterArray.Length; i++)
        //{
        //    if (characterManager.characterArray[0].activeInHierarchy)
        //    {
        //        currentCharacter = characterManager.characterArray[0];
        //        Debug.Log("Active: " + currentCharacter.name);
        //    }
        //    else if (characterManager.characterArray[1].activeInHierarchy)
        //    {
        //        currentCharacter = characterManager.characterArray[1];
        //        Debug.Log("Active: " + currentCharacter.name);
        //    }
        //    else
        //    {
        //        currentCharacter = currentCharacter = characterManager.characterArray[0]; //Default always the first character as a safety for now.
        //        Debug.Log("DEFAULT, no active character yet. The default is: " + currentCharacter.GetComponent<Character>().characterName);
        //    }
        //}
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
            //currentCharacter.GetComponent<QuizManager>().Correct();
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            //currentCharacter.GetComponent<QuizManager>().Correct();
            quizManager.Correct();
        }
    }

    #endregion
}
