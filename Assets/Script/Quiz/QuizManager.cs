using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variable
    public List<QandA> questions_Answers;
    public GameObject[] options;
    public int currentQuestion = 0;
    public CharacterManager CharacterManager;

    public Text currentCharacterText;
    public Text thisGameObjectText;
    public Text questionText;

    private bool characterHasSpawned;
    private bool questionExist;
    private GameObject currentCharacter;
    private List<QandA> currentCharacterQandA;

    #endregion

    #region Method 
    public void Start()
    {
        characterHasSpawned = false;
        questionExist = false;
        Debug.Log("QuizManager is active");
    }

    public void Update()
    {
        if (!questionExist)
        {
            for (int i = 0; i < CharacterManager.characterArray.Length; i++)
            {
                if (CharacterManager.characterArray.Length == 0)
                {
                    Debug.LogError("CharacterArray in CharacterManager is empty, you need to add the prefabs in the editor!");
                }
                else
                {
                    foreach (GameObject character in CharacterManager.characterArray)
                    {
                        if (character.activeInHierarchy)
                        {
                            characterHasSpawned = true;
                            currentCharacter = character;
                            currentCharacterQandA = currentCharacter.GetComponent<Character>().questionsAndAnswers;
                        }
                        else
                        {
                            Debug.Log("waiting for character to spawn.");
                        }
                    }
                }
            }

            if (characterHasSpawned)
            {
                GenerateQuestion();
            }
        }
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerClass>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = currentCharacterQandA[currentQuestion].answers[i];

            if (currentCharacterQandA[currentQuestion].correctAnswers == i + 1)
            {
                options[i].GetComponent<AnswerClass>().isCorrect = true;
            }
        }
    }

    public void Correct()
    {
        // Uncomment when we read the QnA from the class instead
        //if (questions_Answers.Count < 0)
        //{

        currentCharacterQandA.RemoveAt(currentQuestion);
        //questions_Answers.RemoveAt(currentQuestion);
        GenerateQuestion();
        //}
        //else
        //{
        //    Debug.Log("No more questions");
        //}
    }

    private void GenerateQuestion()
    {
        // Uncomment when we read the QnA from the class instead
        //if(questions_Answers.Count < 0)
        //{
        //Not really random tho

        if (currentCharacterQandA.Count < 0)
        {
            return;
        }
        currentQuestion = Random.RandomRange(0, currentCharacterQandA.Count);

        questionText.text = currentCharacterQandA[currentQuestion].question;
        SetAnswers();
        questionExist = true;
        //}
        //else
        //{
        //    Debug.Log("No more question to generate");
        //}
    }
    #endregion
}
