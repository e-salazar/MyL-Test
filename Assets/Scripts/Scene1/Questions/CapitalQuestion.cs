using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scene1.Questions {
    public class CapitalQuestion : Question {
        private string _country;
        private Dictionary<string, string> _countryInfo = new Dictionary<string, string>() {
        { "Chile", "Santiago" },
        { "Argentina", "Buenos Aires" },
        { "China", "Beijing" },
        { "Spain", "Madrid" },
        { "Czech Republic", "Prague" },
        { "Denmark", "Copenhagen" },
        { "France", "Paris" },
        { "Italy", "Rome" },
        { "United Kingdom", "London" },
        { "Thailand", "Bangkok" },
        { "Sri Lanka", "Sri Jayawardenepura Kotte" },
    };

        public override void CreateQuestion() {
            this._country = this._countryInfo.ElementAt(Random.Range(0, this._countryInfo.Count)).Key;
            this.question = "What is the capital city of " + this._country + "?";
            Debug.Log("Hint: " + this._countryInfo[this._country] + ".");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower() == this._countryInfo[this._country].ToLower()) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}