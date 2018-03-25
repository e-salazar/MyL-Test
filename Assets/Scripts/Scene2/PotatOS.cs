using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatOS : MonoBehaviour {
    public Text text;
    public AudioSource audioSource;
    public Animator animator;

    public List<QuestionAnswer> questionsAnswers = new List<QuestionAnswer>() {
        new FibonacciQA(),
        new SumQA(),
        new PurposeQA(),
        new ProductQA(),
        new EvenOrOddQA(),
        new PalindromeQA(),
        new CapitalQA(),
        new SynonymsQA(),
        new AcronymQA(),
        new AnagramQA()
    };

    public QuestionAnswer actualQuestionAnswer;

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
                case QuestionAnswer.AnswerResult.Correct:
                    OnCorrectAnswer();
                    StartCoroutine(NewQuestion(1));
                    break;
                case QuestionAnswer.AnswerResult.Incorrect:
                    OnIncorrectAnswer();
                    StartCoroutine(RepeatQuestion(1));
                    break;
                case QuestionAnswer.AnswerResult.Invalid:
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