using System.Collections.Generic;
using hk.Common.Tests;
using Moq;
using NUnit.Framework;

namespace ArithmeticQuiz.Tests
{
    [TestFixture, TimerAction("QuizFixture")]
    public class QuizFixture
    {
        Student student = new Student("Hussain", "Khan");

        [Test]
        public void TestEnterName()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.SetupSequence(r => r.Read()).Returns("Hussain").Returns("Khan");

            Quiz quiz = new Quiz(reader.Object);
            quiz.EnterName();

            Assert.That(quiz.User, Is.EqualTo("Hussain Khan"));
        }

        [Test]
        public void TestCorrectlyAnsweredAddition()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestCorrectlyAnsweredSubtraction()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");


            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Subtraction));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestCorrectlyAnsweredMultiplication()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("50");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Multiplication));
                
            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestIncorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.Not.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(0));
        }

        [Test]
        public void TestTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.SetupSequence(r => r.Read()).Returns("15").Returns("20");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));
            questions.AddQuestion(new Question(4, 5, Operands.Multiplication));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.GetQuestion(2).CorrectAnswer, Is.EqualTo(questions.GetQuestion(2).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(100));
        }

        [Test]
        public void TestOneOfTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.SetupSequence(r => r.Read()).Returns("15").Returns("25");

            Questions questions = new Questions();
            questions.AddQuestion(new Question(10, 5, Operands.Addition));
            questions.AddQuestion(new Question(4, 5, Operands.Multiplication));

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestionsToStudent(questions, student);

            Assert.That(questions.GetQuestion(1).CorrectAnswer, Is.EqualTo(questions.GetQuestion(1).TheirAnswer));
            Assert.That(questions.GetQuestion(2).CorrectAnswer, Is.Not.EqualTo(questions.GetQuestion(2).TheirAnswer));
            Assert.That(questions.CalculateScorePercentage(), Is.EqualTo(50));
        }
    }
}
