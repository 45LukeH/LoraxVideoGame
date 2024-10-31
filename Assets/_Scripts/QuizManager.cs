using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionTxt;
    [SerializeField] private Health playerHealth;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        Debug.Log("Correct Answer Triggered in QuizManager");

        // Only remove the current question on a correct answer
        if (QnA.Count > 0)
        {
            QnA.RemoveAt(currentQuestion); // Remove the answered question
        }

        // Generate the next question
        generateQuestion();
    }

    public void IncorrectAnswer()
    {
        playerHealth.TakeDamage(1);
        Debug.Log("Incorrect Answer Triggered in QuizManager");

        // Generate the next question regardless of correct/incorrect answer
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
        
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        // Check if there are questions left
        if (QnA.Count > 0)
        {
            // Select a new question index
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            // Optionally, handle the end of the quiz here
        }
    }
}
