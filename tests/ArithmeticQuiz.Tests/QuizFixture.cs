using System.Collections.Generic;
using hk.Common.Tests;
using Moq;
using NUnit.Framework;

namespace ArithmeticQuiz.Tests
{
    [TestFixture, TimerAction("QuizFixture")]
    public class QuizFixture
    {
        [Test]
        public void TestEnterName()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("Hussain");

            Quiz quiz = new Quiz(reader.Object);
            quiz.EnterName();

            Assert.That(quiz.User, Is.EqualTo("Hussain"));
        }

        [Test]
        public void TestCorrectlyAnsweredAddition()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Addition)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.EqualTo(questions[0].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(100));

        }

        [Test]
        public void TestCorrectlyAnsweredSubtraction()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Subtraction)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.EqualTo(questions[0].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(100));
        }

        [Test]
        public void TestCorrectlyAnsweredMultiplication()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("50");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Multiplication)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.EqualTo(questions[0].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(100));
        }

        [Test]
        public void TestIncorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Addition)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.Not.EqualTo(questions[0].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(0));
        }

        [Test]
        public void TestTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Addition),
                new Question(3, 5, Operands.Multiplication)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.EqualTo(questions[0].TheirAnswer));
            Assert.That(questions[1].CorrectAnswer, Is.EqualTo(questions[1].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(100));
        }

        [Test]
        public void TestOneOfTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("15");

            IList<IQuestion> questions = new List<IQuestion>()
            {
                new Question(10, 5, Operands.Addition),
                new Question(4, 5, Operands.Multiplication)
            };

            Quiz quiz = new Quiz(reader.Object);
            quiz.AskQuestions(questions);

            Assert.That(questions[0].CorrectAnswer, Is.EqualTo(questions[0].TheirAnswer));
            Assert.That(questions[1].CorrectAnswer, Is.Not.EqualTo(questions[1].TheirAnswer));
            Assert.That(quiz.PercentageScore, Is.EqualTo(50));
        }
    }
}
