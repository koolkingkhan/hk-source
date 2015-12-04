using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticQuiz
{
    public class Questions : IQuestions
    {
        private readonly List<IQuestion> _questions = new List<IQuestion>(); 
        
        public int TestNumber { get; set; }

        public int Count
        {
            get
            {
                return _questions.Count; 
            }
        }

        //Question numbers start at 1
        public IQuestion GetQuestion(int questionNo)
        {
            int actual = questionNo - 1;
            if (actual >= 0 && actual <= _questions.Count)
            {
                return _questions[actual];
            }
            return null;
        }

        public void AddQuestion(IQuestion question)
        {
            _questions.Add(question);
        }


        public int GetCorrectlyAnswered()
        {
            return _questions.TakeWhile(q => q.TheirAnswer.HasValue && q.TheirAnswer == q.CorrectAnswer).Count();
        }

        public double CalculateScorePercentage()
        {
            return ((double)GetCorrectlyAnswered() / (double)_questions.Count) * 100;
        }
    }
}
