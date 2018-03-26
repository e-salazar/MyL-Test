namespace Scene1.Questions {
    public abstract class Question {
        public enum AnswerResult {
            Correct,
            Incorrect,
            Invalid,
        }

        public string question;

        public abstract void CreateQuestion();
        public abstract AnswerResult CheckAnswer(string answerText);
    }
}