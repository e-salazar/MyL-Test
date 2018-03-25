using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnagramQA : QuestionAnswer {
    private int _index;
    private List<string> _anagrams = new List<string>() {
        "car",
        "bus",
        "latitude",
        "lakes",
        "artist",
        "north",
        "south",
        "east",
        "west",
        "ocean",
    };

    public override void CreateQuestion() {
        this._index = Random.Range(0, this._anagrams.Count);
        this.question = "Write an anagram of " + this._anagrams[this._index].ToLower() + ".";
        Debug.Log("Hint: " + new string(this._anagrams[this._index].Reverse().ToArray()) + ".");
    }
    public override AnswerResult CheckAnswer(string answerText) {
        if(answerText.ToLower() == this._anagrams[this._index].ToLower()) { return AnswerResult.Invalid; }

        if(answerText.ToLower().OrderBy(c => c).SequenceEqual(this._anagrams[this._index].ToLower().OrderBy(c => c))) {
            return AnswerResult.Correct;
        }
        else {
            return AnswerResult.Incorrect;
        }
    }
}