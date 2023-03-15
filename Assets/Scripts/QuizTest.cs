using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTest : MonoBehaviour
{
    public GameObject quizBox;
    public Text questionText;
    public Text scoreText;
    public Button[] answerButtons;
    public Button startButton;

    private Question[] questions;
    private int currentQuestionIndex;
    private int score;

    void Start()
    {
        quizBox.SetActive(false);
        //init questions
        questions = new Question[]
        {
            new Question("This is a test question", new string[]{"this is a wrong answer", "this is the right answer", "this is a wrong answer", "this is a wrong answer"}, 1),
            new Question("What is the model supposed to be?", new string[]{ "ambulance", "helicopter", "ice cream", "the tetris videogame"}, 0),
        };

        currentQuestionIndex = 0;
        score = 0;
        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(() => AnswerButtonClicked(buttonIndex));
        }
        startButton.onClick.AddListener(ShowQuestion);
    }

    void ShowQuestion()
    {
        startButton.gameObject.SetActive(false);
        quizBox.SetActive(true);

        questionText.text = questions[currentQuestionIndex].question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = questions[currentQuestionIndex].answers[i];
        }
    }

    public void AnswerButtonClicked(int buttonIndex)
    {
        if (buttonIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    void EndQuiz()
    {
        Debug.Log("quiz over, score " + score.ToString());
        quizBox.SetActive(false);
        startButton.gameObject.SetActive(true);
        //reset quiz
        currentQuestionIndex = 0;
        //implement way to add score to a database
    }
}

public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;

    public Question(string question, string[] answers, int correctAnswerIndex)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}