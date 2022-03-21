using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Variables
    public int ID;
    public string characterName;
    private GameObject quizManager;
    public List<QandA> questionsAndAnswers;
    private GameObject quizPrefab;

    private bool isActiveInHierarchy;
    private bool questionHasBeenAdded;

    #endregion

    #region Method
    public void Start()
    {
        quizManager = FindMyGameObject("QuizManager");
        quizPrefab = FindMyGameObject("CanvasQuiz");
        quizManager.SetActive(true);
        AddQuestionsAndAnswersToCharactersList();
        quizPrefab.SetActive(true);
    }

    private GameObject FindMyGameObject(string name)
    {
        Transform[] myResources = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < myResources.Length; i++)
        {
            if (myResources[i].CompareTag(name))
            {
                Debug.Log("Character FindMYGameobjc : name " + myResources[i].tag);
                return myResources[i].gameObject;
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
                 //questionsAndAnswers.Add(quizManager.GetComponent<QuizManager>().questions_Answers[2]);
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
