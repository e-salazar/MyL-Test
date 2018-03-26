using Scene1.Questions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Manager : MonoBehaviour {
    public Text text;
    public AudioSource audioSource;
    public Animator animator;

    public List<Question> questionsAnswers = new List<Question>() {
        new FibonacciQuestion(),
        new SumQuestion(),
        new PurposeQuestion(),
        new ProductQuestion(),
        new EvenOrOddQuestion(),
        new PalindromeQuestion(),
        new CapitalQuestion(),
        new SynonymsQuestion(),
        new AcronymQuestion(),
        new AnagramQuestion()
    };

    public Question actualQuestionAnswer;

    private void Start() {
        text.text = "Hi...";
        animator.SetTrigger("Presentate");
        StartCoroutine(NewQuestion(3));
    }

    public void PlayAudio(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public IEnumerator NewQuestion(float delay) {
        yield return new WaitForSeconds(delay);

        actualQuestionAnswer = questionsAnswers[Random.Range(0, questionsAnswers.Count)];
        actualQuestionAnswer.CreateQuestion();
        text.text = actualQuestionAnswer.question;
    }
    public IEnumerator RepeatQuestion(float delay) {
        yield return new WaitForSeconds(delay);

        text.text = actualQuestionAnswer.question;
    }
    public void OnEndEditAnswer(InputField inputField) {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            if(actualQuestionAnswer == null) { return; }
            switch(actualQuestionAnswer.CheckAnswer(inputField.text)) {
                case Question.AnswerResult.Correct:
                    OnCorrectAnswer();
                    StartCoroutine(NewQuestion(1));
                    break;
                case Question.AnswerResult.Incorrect:
                    OnIncorrectAnswer();
                    StartCoroutine(RepeatQuestion(1));
                    break;
                case Question.AnswerResult.Invalid:
                    OnInvalidAnswer();
                    StartCoroutine(RepeatQuestion(1));
                    break;
            }

            inputField.text = "";
            inputField.ActivateInputField();
            inputField.Select();
        }
    }

    public void OnCorrectAnswer() {
        text.text = "Correct!";
        animator.SetTrigger("Correct");
    }
    public void OnIncorrectAnswer() {
        text.text = "Incorrect!";
        animator.SetTrigger("Incorrect");
    }
    public void OnInvalidAnswer() {
        text.text = "?????";
        animator.SetTrigger("Invalid");
    }
}