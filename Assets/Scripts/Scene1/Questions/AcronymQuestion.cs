using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scene1.Questions {
    public class AcronymQuestion : Question {
        private List<string> _words = new List<string>() {
        "United",
        "States",
        "America",
        "Forces",
        "International",
        "Organization",
        "Federation",
        "Association",
        "Potatoes",
    };
        private string _acronym;

        public override void CreateQuestion() {
            int wordsCount = Random.Range(3, 5);
            List<string> words = new List<string>();

            string pickedWord;
            for(int i = 0; i < wordsCount; i++) {
                pickedWord = this._words[Random.Range(0, this._words.Count)];
                while(words.Contains(pickedWord)) {//Si la lista ya contiene la palabra, la cambiamos para que no se repita
                    pickedWord = this._words[Random.Range(0, this._words.Count)];
                }
                words.Add(pickedWord);
            }
            this._acronym = new string(words.Select(word => word[0]).ToArray());

            this.question = "What is the acronym of " + System.String.Join(" ", words.ToArray()) + "?";
            Debug.Log("Hint: " + this._acronym + ".");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower() == this._acronym.ToLower()) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}