using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variable
    public List<QandA> questions_Answers;
    //public GameObject[] options;
    public int currentQuestion = 0;
    //public CharacterManager CharacterManager;

    public Text currentCharacterText;
    public Text thisGameObjectText;
    public Text questionText;

    private bool characterHasSpawned;
    private bool questionExist;
    private GameObject currentCharacter;
    private List<QandA> currentCharacterQandA;
    private GameObject[] answerOptions;

    #endregion

    #region Method 

    public void Start()
    {
        characterHasSpawned = false;
        questionExist = false;
        Debug.Log("QuizManager is active");
        currentCharacter = GameObject.FindGameObjectWithTag("Character");
        Debug.Log("QuizManager Start: Current character: " + currentCharacter.name + ", tag: " + currentCharacter.tag);
        answerOptions = GameObject.FindGameObjectsWithTag("AnswerButton");
        Debug.Log("QuizManager Start: answeroptions " + answerOptions.Length);
    }

    public void Update()
    {
        if (!questionExist)
        {
            Debug.Log("Manager Updater");

            if (currentCharacter != null)
            {
                characterHasSpawned = true;
                currentCharacterQandA = currentCharacter.GetComponent<Character>().questionsAndAnswers;
                Debug.Log("QuizManager Update: current character List of Q&A count: " + currentCharacterQandA.Count);
                if(currentCharacterQandA.Count > 0)
                {
                    Debug.Log("QuizManager Update: Calling GenerateQuestion()");
                    GenerateQuestion();
                }
            }
        }
    }

    private void SetAnswers()
    {
        for (int i = 0; i < answerOptions.Length; i++)
        {
            answerOptions[i].GetComponent<AnswerClass>().isCorrect = false;
            answerOptions[i].transform.GetChild(0).GetComponent<Text>().text = currentCharacterQandA[currentQuestion].answers[i];

            if (currentCharacterQandA[currentQuestion].correctAnswers == i + 1)
            {
                answerOptions[i].GetComponent<AnswerClass>().isCorrect = true;
            }
            Debug.Log("QuizManagewr SetAnswer: Setting answer" + answerOptions[i]);
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
            Debug.Log("HEEEJ");
            return;
        }
        else
        {
            Debug.Log(currentCharacterQandA.Count + " Amount of current answre");
        }
        currentQuestion = Random.Range(0, currentCharacterQandA.Count);
        questionText.text = currentCharacterQandA[currentQuestion].question;
        Debug.Log("QuizManager GanerateQuestion: question text: " + questionText.text);
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
