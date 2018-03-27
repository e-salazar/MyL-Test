using UnityEngine;

namespace Scene1.Questions {
    public class LupitaQuestion : Question {
        public override void CreateQuestion() {
            this.question = "¿Qué le pasa a Lupita?";
            Debug.Log("Hint: No sé.");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower() == "no sé") {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}