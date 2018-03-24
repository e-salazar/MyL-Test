using UnityEngine;

public class SumQA : QuestionAnswer {
    private int _a;
    private int _b;

    public override void CreateQuestion() {
        this._a = Random.Range(1, 10);
        this._b = Random.Range(1, 10);
        this.question = "What is " + this._a + "+" + this._b + "?";
        Debug.Log("Hint: " + (this._a + this._b) + ".");
    }
    public override AnswerResult CheckAnswer(string answerText) {
        int answer;
        if(!int.TryParse(answerText, out answer)) { return AnswerResult.Invalid; }

        if(answer == (this._a + this._b)) {
            return AnswerResult.Correct;
        }
        else {
            return AnswerResult.Incorrect;
        }
    }
}