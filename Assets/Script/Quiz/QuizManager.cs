using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variable
    public List<QandA> questions_Answers;
    public int currentQuestion = 0;
    public Text questionText;

    private bool questionExist;
    private GameObject currentCharacter;
    private List<QandA> currentCharacterQandA;
    private List<GameObject> answerOptions;
    private GameObject quizPrefab;

    #endregion

    #region Method 

    public void Start()
    {
        quizPrefab = FindMyGameObject("CanvasQuiz");
        questionExist = false;
        Debug.Log("QuizManager is active");
        currentCharacter = FindMyGameObject("Character");
        Debug.Log("QuizManager Start: Current character: " + currentCharacter.name + ", tag: " + currentCharacter.tag);
        answerOptions = FindList("AnswerButton");
        Debug.Log("QuizManager Start: answeroptions " + answerOptions.Count);
        ActivateQuiz();
    }

    public void ActivateQuiz()
    {
        quizPrefab.SetActive(true);
    }

    private GameObject FindMyGameObject(string name)
    {
        foreach (GameObject prefabToSpawn in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (prefabToSpawn.CompareTag(name))
            {
                return prefabToSpawn;
            }
        }
        return null;
    }
    private List<GameObject> FindList(string name)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (GameObject prefabToSpawn in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (prefabToSpawn.CompareTag(name))
            {
                temp.Add(prefabToSpawn);
            }
        }
        return temp;
    }
    public void Update()
    {
        if (!questionExist)
        {
            Debug.Log("Manager Updater");

            if (currentCharacter != null && currentCharacter.activeInHierarchy)
            {
                currentCharacterQandA = currentCharacter.GetComponent<Character>().questionsAndAnswers;
                Debug.Log("QuizManager Update: current character List of Q&A count: " + currentCharacterQandA.Count);
                if (currentCharacterQandA.Count > 0)
                {
                    Debug.Log("QuizManager Update: Calling GenerateQuestion()");
                    GenerateQuestion();
                }
            }
        }
    }

    private void SetAnswers()
    {
        for (int i = 0; i < answerOptions.Count; i++)
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
        currentCharacterQandA.RemoveAt(currentQuestion);
        if (currentCharacterQandA.Count > 0)
        {
            GenerateQuestion();
            //End quiz and add highscores
        }
        else
        {
            Debug.Log("QuizManager Correct: currentCharacterQandA Count is less than 0");
        }
    }

    private void GenerateQuestion()
    {
        if (currentCharacterQandA.Count < 0)
        {
            return;
        }
        currentQuestion = Random.Range(0, currentCharacterQandA.Count);
        questionText.text = currentCharacterQandA[currentQuestion].question;
        Debug.Log("QuizManager GanerateQuestion: question text: " + questionText.text);
        SetAnswers();
        questionExist = true;
    }
    #endregion
}
