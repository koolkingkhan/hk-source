using System.Collections.Generic;
using hk.Common.Tests;
using Moq;
using NUnit.Framework;

namespace ArithmeticQuiz.Tests
{
    [TestFixture, TimerAction("QuizFixture")]
    public class QuizFixture
    {
        const int QuestionOne = 1;
        const int QuestionTwo = 2;

        [Test]
        public void TestEnterName()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("Hussain");

            Quiz quiz = new Quiz(reader.Object);
            quiz.EnterName();

            Assert.That(quiz.User, Is.EqualTo("Hussain Hussain"));
        }

        [Test]
        public void TestCorrectlyAnsweredAddition()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));

            Student student = new Student("Hussain", "Khan");

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));

        }

        [Test]
        public void TestCorrectlyAnsweredSubtraction()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Subtraction));

            Student student = new Student("Hussain", "Khan");

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestCorrectlyAnsweredMultiplication()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("50");

            Student student = new Student("Hussain", "Khan");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Multiplication));
                
            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestIncorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            Student student = new Student("Hussain", "Khan");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.Not.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(0));
        }

        [Test]
        public void TestTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            Student student = new Student("Hussain", "Khan");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));
            questions.AddQuestion(new Question(3, 5, Operands.Multiplication));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions[QuestionTwo].CorrectAnswer, Is.EqualTo(questions[QuestionTwo].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestOneOfTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            Student student = new Student("Hussain", "Khan");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));
            questions.AddQuestion(new Question(4, 5, Operands.Multiplication));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions[QuestionOne].CorrectAnswer, Is.EqualTo(questions[QuestionOne].TheirAnswer));
            Assert.That(questions[QuestionTwo].CorrectAnswer, Is.Not.EqualTo(questions[QuestionTwo].TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(50));
        }
    }
}
