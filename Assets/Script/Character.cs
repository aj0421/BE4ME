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
 

    private GameObject quizManager;
    private bool questionHasBeenAdded;
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
