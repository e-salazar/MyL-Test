using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scene1.Questions {
    public class SynonymsQuestion : Question {
        private List<List<string>> _synonymsLists = new List<List<string>>() {
        new List<string>(){ "rejected", "disapproved", "refused" },
        new List<string>(){ "accepted", "approved", "authorized" },
        new List<string>(){ "sent", "emitted", "dispatched" },
    };
        private int _listSelectedIndex = 0;
        private string _noSynonym;

        public override void CreateQuestion() {
            //Para que la lista presentada sea siempre distinta y no estática, se escoge primero una lista de 
            //sinónimos y se le agrega una palabra extra de las otras listas restantes, ese elemento será el 
            //no -sinónimo (todo se escoge al azar para alcanzar un mayor dinamismo).
            this._listSelectedIndex = Random.Range(0, this._synonymsLists.Count);//Una lista de sinónimos al azar
            List<List<string>> otherLists = this._synonymsLists.Where((words, index) => this._listSelectedIndex != index).ToList();//El resto de listas (no-sinónimos de la escogida)
            List<string> noSynonymsList = otherLists.ElementAt(Random.Range(0, otherLists.Count)).ToList();//Escogemos una lista de las otras (los no sinónimos)
            this._noSynonym = noSynonymsList.ElementAt(Random.Range(0, noSynonymsList.Count));
            List<string> questionWords = new List<string>(this._synonymsLists[this._listSelectedIndex]);
            questionWords.Add(this._noSynonym);

            System.Random rng = new System.Random();
            questionWords = questionWords.OrderBy(a => rng.Next()).ToList();

            this.question = "Which of these words is not synonym?: " + System.String.Join(", ", questionWords.ToArray()) + ".";
            Debug.Log("Hint: " + this._noSynonym + ".");
        }
        public override AnswerResult CheckAnswer(string answerText) {
            if(answerText.ToLower() == this._noSynonym.ToLower()) {
                return AnswerResult.Correct;
            }
            else {
                return AnswerResult.Incorrect;
            }
        }
    }
}