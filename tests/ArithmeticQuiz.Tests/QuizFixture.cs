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

            Quiz quiz = new Quiz(reader.Object, new Mock<IRandomQuestionGenerator>().Object);
            quiz.EnterName();

            Assert.That(quiz.User, Is.EqualTo("Hussain"));
        }

        [Test]
        public void TestCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("50");

            Mock<IRandomQuestionGenerator> questionGenerator = new Mock<IRandomQuestionGenerator>();
            questionGenerator.Setup(q => q.Lhs).Returns(10);
            questionGenerator.Setup(q => q.Rhs).Returns(5);
            questionGenerator.Setup(q => q.OperandAsString).Returns("*");
            questionGenerator.Setup(q => q.Answer).Returns(50);

            Quiz quiz = new Quiz(reader.Object, questionGenerator.Object);
            quiz.AskQuestions(1);

            Assert.That(quiz.CorrectAnswer, Is.EqualTo(quiz.TheirAnswer));
        }

        [Test]
        public void TestIncorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("5");

            Mock<IRandomQuestionGenerator> questionGenerator = new Mock<IRandomQuestionGenerator>();
            questionGenerator.Setup(q => q.Lhs).Returns(10);
            questionGenerator.Setup(q => q.Rhs).Returns(5);
            questionGenerator.Setup(q => q.OperandAsString).Returns("*");
            questionGenerator.Setup(q => q.Answer).Returns(50);

            Quiz quiz = new Quiz(reader.Object, questionGenerator.Object);
            quiz.AskQuestions(1);

            Assert.That(quiz.CorrectAnswer, Is.Not.EqualTo(quiz.TheirAnswer));
        }

        [Test]
        public void TestTwoCorrectlyAnswered()
        {
            Mock<IConsoleReader> reader = new Mock<IConsoleReader>();
            reader.Setup(r => r.Read()).Returns("50");

            Mock<IRandomQuestionGenerator> questionGenerator = new Mock<IRandomQuestionGenerator>();
            questionGenerator.Setup(q => q.Lhs).Returns(10);
            questionGenerator.Setup(q => q.Rhs).Returns(5);
            questionGenerator.Setup(q => q.OperandAsString).Returns("*");
            questionGenerator.Setup(q => q.Answer).Returns(50);

            Quiz quiz = new Quiz(reader.Object, questionGenerator.Object);
            quiz.AskQuestions(2);

            Assert.That(quiz.CorrectAnswer, Is.EqualTo(quiz.TheirAnswer));
        }
    }
}
