using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scene1.Questions {
    public class ParadoxQuestion : Question {
        private List<string> _paradoxes = new List<string>() {
            "<i>\"This sentence is false.\"</i>\n The sentence above is: True or False?",
            "<i>\"I am lying.\"</i>\n The sentence above is: True or False?",
            "<i>\"It’s raining, and this sentence is false.\"</i>\n So. Is it raining?",
            "Sentence 1: <i>\"Sentence 2 is true.\"</i>\nSentence 2: <i>\"Sentence 1 is false.\"</i>\n So. Which sentence is true?",
        };

        public override void CreateQuestion() {
            this.question = this._paradoxes.ElementAt(Random.Range(0, this._paradoxes.Count));
            Debug.Log("Hint: ...");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            return AnswerResult.Paradox;
        }
    }
}