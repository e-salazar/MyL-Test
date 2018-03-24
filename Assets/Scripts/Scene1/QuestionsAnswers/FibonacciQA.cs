using UnityEngine;

public class FibonacciQA : QuestionAnswer {
    private int _position;

    public override void CreateQuestion() {
        this._position = Random.Range(1, 10);
        this.question = "Which number is in " + this._position + "° position in Fibonacci sequence?";
        Debug.Log("Hint: " + Fibonacci(this._position) + ".");
    }
    public override AnswerResult CheckAnswer(string answerText) {
        int answer;
        if(!int.TryParse(answerText, out answer)) { return AnswerResult.Invalid; }

        if(answer == Fibonacci(this._position)) {
            return AnswerResult.Correct;
        }
        else {
            return AnswerResult.Incorrect;
        }
    }

    private int Fibonacci(int n) {
        if(n == 0) {
            return 0;
        }
        else if(n == 1) {
            return 1;
        }
        else {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}