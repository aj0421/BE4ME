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
     
    }
    public void Update()
    {
        //Been in Awake before
        for (int i = 0; i < characterManager.characterArray.Length; i++)
        {
            if (characterManager.characterArray[0].activeInHierarchy)
            {
                currentCharacter = characterManager.characterArray[0];
            }
            else if (characterManager.characterArray[1].activeInHierarchy)
            {
                currentCharacter = characterManager.characterArray[1];
            }
            //TODO: Check characer by id, to make sure exacly which character is the current one from the list.
            //Something like: id == 0 then potision in array is also 0, if id == 1 then position in array is 1 etc. And then set the currentCharacter.
            //currentCharacter = characterManager.characterArray[i];
            //if (characterManager.characterArray[i].GetComponent<Character>().ID == 0)
            //{
            //    currentCharacter = characterManager.characterArray[0];
            //}
            //else if (characterManager.characterArray[i].GetComponent<Character>().ID == 1)
            //{
            //    currentCharacter = characterManager.characterArray[1];
            //}
            else
            {
                currentCharacter = currentCharacter = characterManager.characterArray[0]; //Default always the first character as a safety for now.
            }
        }
        Debug.Log("current c: " + currentCharacter.GetComponent<Character>().characterName);
    }
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            currentCharacter.GetComponent<QuizManager>().Correct();
            //quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            currentCharacter.GetComponent<QuizManager>().Correct();
            //quizManager.Correct();
        }
    }

    #endregion
}
