using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Scene1.Questions {
    public class PalindromeQuestion : Question {
        public override void CreateQuestion() {
            this.question = "Write a palindrome word.";
            Debug.Log("Hint: Ana.");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(!Regex.IsMatch(answerText, @"^[a-zA-Z]+$")) { return AnswerResult.Invalid; }

            if(answerText.SequenceEqual(answerText.Reverse())) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}