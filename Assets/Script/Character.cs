using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Variables

    public int ID;

    public string characterName;

    public QuizManager QuizManager;

    public List<QandA> questionsAndAnswers;

    private bool isActiveInHierarchy;

    private void Start()
    {
        QuizManager.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            isActiveInHierarchy = true;
        }

        if (isActiveInHierarchy)
        {
            AddQuestionsAndAnswersToCharactersList(ID);   //ÄR LITE OROLIG ÖVER DENNA? Hmmmmm. Ska det vara: GetComponent<Character>().ID ?
        }
    }

    private void AddQuestionsAndAnswersToCharactersList(int ID_)
    {
        for (int i = 0; i < QuizManager.questions_Answers.Count; i++)
        {
            if (ID == ID_)
            {
                questionsAndAnswers.Add(QuizManager.questions_Answers[0]);
            }
            else if (ID == ID_)
            {
                questionsAndAnswers.Add(QuizManager.questions_Answers[1]);
            }
        }
    }

    #endregion
}
