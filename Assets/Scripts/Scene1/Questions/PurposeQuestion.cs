using UnityEngine;

namespace Scene1.Questions {
    public class PurposeQuestion : Question {
        public override void CreateQuestion() {
            this.question = "What is my purpose?";
            Debug.Log("Hint: Use a phrase which includes the words: 'pass', 'butter', 'make' and 'questions'.");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower().Contains("pass") && answerText.ToLower().Contains("butter") && answerText.ToLower().Contains("make") && answerText.ToLower().Contains("questions")) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}