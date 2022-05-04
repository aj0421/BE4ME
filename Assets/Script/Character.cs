using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Variables
    public int ID;
    public string characterName;
    public string year;
    public List<QandA> questionsAndAnswers;
    public bool isCompleted = false;

    private GameObject quizManager;
    private bool questionHasBeenAdded;
    private List<QandA> questions_Answers;
    #endregion

    #region Method
    public void Start()
    {
        quizManager = FindMyGameObject("QuizManager");
        quizManager.SetActive(true);
        AddQuestionsAndAnswersToCharactersList();
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

    private void SetQandAs()
    {
        QuestionHolder QuestionHolder = new QuestionHolder();
        questions_Answers = new List<QandA>();
        questions_Answers.Add(QuestionHolder.Q1());
        questions_Answers.Add(QuestionHolder.Q2());
        questions_Answers.Add(QuestionHolder.Q3());
        questions_Answers.Add(QuestionHolder.Q4());
        questions_Answers.Add(QuestionHolder.Q5());
        questions_Answers.Add(QuestionHolder.Q6());
    }

    private void AddQuestionsAndAnswersToCharactersList()
    {
        SetQandAs();

        for (int i = 0; i < quizManager.GetComponent<QuizManager>().questions_Answers.Count; i++)
        {
            if (ID == 0 && !questionHasBeenAdded)
            {
                questionsAndAnswers.Add(questions_Answers[0]);
                questionsAndAnswers.Add(questions_Answers[1]);
                questionHasBeenAdded = true;
            }
            else if (ID == 1 && !questionHasBeenAdded)
            {
                questionsAndAnswers.Add(questions_Answers[2]);
                questionsAndAnswers.Add(questions_Answers[3]);
                questionHasBeenAdded = true;
            }  
            else if (ID == 2 && !questionHasBeenAdded)
            {
                questionsAndAnswers.Add(questions_Answers[4]);
                questionsAndAnswers.Add(questions_Answers[5]);
                questionHasBeenAdded = true;
            } 
        }
    }
    #endregion
}
