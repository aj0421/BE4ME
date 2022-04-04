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
    public Button exitButton;

    private bool questionExist;
    private GameObject currentCharacter;
    private List<QandA> currentCharacterQandA;
    private List<GameObject> answerOptions;
    private GameObject quizPrefab;
    public GameObject guiPrefab;
    public GameObject scorePrefab;
    public GameObject quizPanel;
    private GameObject characterManager;

    #endregion

    #region Method 

    public void Start()
    {
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        quizPrefab = FindMyGameObject("CanvasQuiz");
        questionExist = false;
        Debug.Log("QuizManager is active");
        currentCharacter = FindMyGameObject("Character");
        Debug.Log("QuizManager Start: Current character: " + currentCharacter.name + ", tag: " + currentCharacter.tag);
        answerOptions = FindList("AnswerButton");
        Debug.Log("QuizManager Start: answeroptions " + answerOptions.Count);
    }
    public void ActivateQuiz()
    {
        quizPrefab.SetActive(true);
        guiPrefab.SetActive(false);
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
        if (!currentCharacter.GetComponent<Character>().isCompleted)
        {
            if (!questionExist)
            {
                if (currentCharacter != null && currentCharacter.activeInHierarchy)
                {
                    currentCharacterQandA = currentCharacter.GetComponent<Character>().questionsAndAnswers;
                    if (currentCharacterQandA.Count > 0)
                    {
                        GenerateQuestion();
                    }
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
            Debug.Log("QuizManager SetAnswer: Setting answer" + answerOptions[i]);
        }
    }

    public void Correct()
    {
        currentCharacterQandA.RemoveAt(currentQuestion);
        if (currentCharacterQandA.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            quizPanel.SetActive(false);
            scorePrefab.SetActive(true);
            currentCharacter.GetComponent<Character>().isCompleted = true;
            characterManager.GetComponent<CharacterManager>().isCompleted = currentCharacter.GetComponent<Character>().isCompleted;
            exitButton.gameObject.SetActive(true);
            Debug.Log("QuizManager Correct: currentCharacterQandA Count is less than 0");
            return;
        }
    }

    public void PressExit()
    {
        quizPrefab.SetActive(false);
        guiPrefab.SetActive(true);
    }
    private void GenerateQuestion()
    {
        if (currentCharacterQandA.Count <= 0)
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
