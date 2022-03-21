using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Variables
    public int ID;
    public string characterName;
    public GameObject quizManager;
    public List<QandA> questionsAndAnswers;
    public GameObject quizPrefab;

    private bool isActiveInHierarchy;
    private bool questionHasBeenAdded;
    
    #endregion

    #region Method
    public void Start()
    {
        AddQuestionsAndAnswersToCharactersList();     
        quizManager.SetActive(true);
        quizPrefab.SetActive(true);
    }

    private void AddQuestionsAndAnswersToCharactersList()
    {
        for (int i = 0; i < quizManager.GetComponent<QuizManager>().questions_Answers.Count; i++)
        {
            if (ID == 0 && !questionHasBeenAdded)
            {
                questionsAndAnswers.Add(quizManager.GetComponent<QuizManager>().questions_Answers[0]);
                questionsAndAnswers.Add(quizManager.GetComponent<QuizManager>().questions_Answers[2]);
                questionHasBeenAdded = true;
                Debug.Log("ID 0 Count; " + questionsAndAnswers.Count);
            }
            else if (ID == 1 && !questionHasBeenAdded)
            {
                questionsAndAnswers.Add(quizManager.GetComponent<QuizManager>().questions_Answers[1]);
                questionHasBeenAdded = true;
            }
        }
    }
    #endregion
}
