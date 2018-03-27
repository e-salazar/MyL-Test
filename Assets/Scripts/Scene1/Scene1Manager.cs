using Scene1.Questions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Manager : MonoBehaviour {
    public Text text;
    public AudioSource audioSource;
    public Animator animator;
    public bool animating;

    public List<Question> questions = new List<Question>() {
        new FibonacciQuestion(),
        new SumQuestion(),
        new PurposeQuestion(),
        new ProductQuestion(),
        new EvenOrOddQuestion(),
        new PalindromeQuestion(),
        new CapitalQuestion(),
        new SynonymsQuestion(),
        new AcronymQuestion(),
        new AnagramQuestion(),
        new LupitaQuestion(),
        new ParadoxQuestion(),
    };

    public Question actualQuestion;

    private void Start() {
        this.animating = true;
        text.text = "Hi...";
        animator.SetInteger("Presentation", Random.Range(0, 3));
        animator.SetTrigger("Presentate");
    }

    public void PlayAudio(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void NewQuestion() {
        actualQuestion = questions[Random.Range(0, questions.Count)];
        actualQuestion.CreateQuestion();
        text.text = actualQuestion.question;
        this.animating = false;
        if(actualQuestion is ParadoxQuestion) {
            animator.SetTrigger("ParadoxTime");
        }
    }
    public void RepeatQuestion() {
        text.text = actualQuestion.question;
        this.animating = false;
    }
    public void OnEndEditAnswer(InputField inputField) {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            if(this.actualQuestion == null) { return; }
            if(this.animating) { return; }

            this.animating = true;

            switch(actualQuestion.CheckAnswer(inputField.text)) {
                case Question.AnswerResult.Correct:
                    OnCorrectAnswer();
                    break;
                case Question.AnswerResult.Incorrect:
                    OnIncorrectAnswer();
                    break;
                case Question.AnswerResult.Invalid:
                    OnInvalidAnswer();
                    break;
                case Question.AnswerResult.Paradox:
                    OnParadoxAnswer();
                    break;
            }

            inputField.text = "";
            inputField.ActivateInputField();
            inputField.Select();
        }
    }

    public void OnCorrectAnswer() {
        text.text = "Correct!";
        animator.SetInteger("CorrectAnswer", (animator.GetInteger("CorrectAnswer") + 1) % 3);
        animator.SetTrigger("Correct");
    }
    public void OnIncorrectAnswer() {
        text.text = "Incorrect!";
        animator.SetInteger("IncorrectAnswer", (animator.GetInteger("IncorrectAnswer") + 1) % 3);
        animator.SetTrigger("Incorrect");
    }
    public void OnInvalidAnswer() {
        text.text = "?????";
        animator.SetInteger("InvalidAnswer", (animator.GetInteger("InvalidAnswer") + 1) % 3);
        animator.SetTrigger("Invalid");
    }
    public void OnParadoxAnswer() {
        animator.SetTrigger("ParadoxAnswer");
        text.text = "It's a paradox! There IS no answer!";
    }
}