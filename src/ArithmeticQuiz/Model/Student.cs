using System.Collections.Generic;

namespace ArithmeticQuiz
{
    public class Student
    {
        private readonly double[] _scores = new double[3];
 
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = FirstName + " " + LastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }

        public void AddScore(int quizNo, double score)
        {
            _scores[quizNo] = score;
        }
    }
}
