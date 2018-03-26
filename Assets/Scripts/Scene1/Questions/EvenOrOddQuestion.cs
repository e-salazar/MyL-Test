using UnityEngine;

namespace Scene1.Questions {
    public class EvenOrOddQuestion : Question {
        private int _a;

        public override void CreateQuestion() {
            this._a = Random.Range(1, 10);
            this.question = "Is " + this._a + " an even or an odd number?";
            Debug.Log("Hint: " + (this._a % 2 == 0 ? "Even" : "Odd") + ".");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower() != "even" && answerText.ToLower() != "odd") { return AnswerResult.Invalid; }

            if((answerText.ToLower() == "even" && this._a % 2 == 0) || (answerText.ToLower() == "odd" && this._a % 2 == 1)) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}