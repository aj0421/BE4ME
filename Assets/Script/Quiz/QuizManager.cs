using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variable
    //public List<QandA> questions_Answers;
    
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
        currentCharacter = FindMyGameObject("Character");
        answerOptions = FindList("AnswerButton");
        //SetQandAs();
    }

    private void SetQandAs()
    {
        QuestionHolder QuestionHolder = new QuestionHolder();
        questions_Answers = new List<QandA>();
        questions_Answers.Add(QuestionHolder.Q1());
        questions_Answers.Add(QuestionHolder.Q2());
        Debug.Log("Q and A: " + questions_Answers[0].question + " + " + questions_Answers[1].question);
    }

    public void ActivateQuiz()
    {
        quizPrefab.SetActive(true);
        guiPrefab.SetActive(false);
    }

    #region FindObjects

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

    #endregion

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
            return;
        }
    }

    public void PressExit()
    {
        if (characterManager.GetComponent<CharacterManager>().storedValue == "1900" && currentCharacterQandA.Count <= 0)
        {
            SceneManager.LoadScene(4);
            SaveScore.Instance.SaveFile();
        }
        else
        {
            quizPrefab.SetActive(false);
            guiPrefab.SetActive(true);
            ExitFromQuizToMap();
        }
    }

    public void ExitFromQuizToMap()
    {
        SceneManager.LoadScene(1);
    }

    private void GenerateQuestion()
    {
        if (currentCharacterQandA.Count <= 0)
        {
            return;
        }
        currentQuestion = Random.Range(0, currentCharacterQandA.Count);
        questionText.text = currentCharacterQandA[currentQuestion].question;
        SetAnswers();
        questionExist = true;
    }
    #endregion
}
