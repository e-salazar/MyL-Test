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
        UtilitiesManager.Instance.DelayedFunction(NewQuestion, 3);
    }

    public void PlayAudio(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void NewQuestion() {
        actualQuestionAnswer = questionsAnswers[Random.Range(0, questionsAnswers.Count)];
        actualQuestionAnswer.CreateQuestion();
        text.text = actualQuestionAnswer.question;
    }
    public void RepeatQuestion() {
        text.text = actualQuestionAnswer.question;
    }
    public void OnEndEditAnswer(InputField inputField) {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            switch(actualQuestionAnswer.CheckAnswer(inputField.text)) {
                case QuestionAnswer.AnswerResult.Correct:
                    OnCorrectAnswer();
                    UtilitiesManager.Instance.DelayedFunction(NewQuestion, 1f);
                    break;
                case QuestionAnswer.AnswerResult.Incorrect:
                    OnIncorrectAnswer();
                    UtilitiesManager.Instance.DelayedFunction(RepeatQuestion, 1f);
                    break;
                case QuestionAnswer.AnswerResult.Invalid:
                    OnInvalidAnswer();
                    UtilitiesManager.Instance.DelayedFunction(RepeatQuestion, 1f);
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