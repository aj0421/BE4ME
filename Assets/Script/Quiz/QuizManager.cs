using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region Variable
    public List<QandA> questions_Answers;
    public GameObject[] options;
    public int currentQuestion;

    public Text questionText;
    #endregion

    #region Method 
    public void Start()
    {
        GenerateQuestion();        
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerClass>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questions_Answers[currentQuestion].answers[i];

            if(questions_Answers[currentQuestion].correctAnswers == i+1)
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
        questions_Answers.RemoveAt(currentQuestion);
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
            currentQuestion = Random.RandomRange(0, questions_Answers.Count);

            questionText.text = questions_Answers[currentQuestion].question;
            SetAnswers();

        //}
        //else
        //{
        //    Debug.Log("No more question to generate");
        //}

    }
    #endregion
}
