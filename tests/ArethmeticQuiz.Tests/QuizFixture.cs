using ArithmeticQuiz;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ArethmeticQuiz.Tests
{
    [TestFixture]
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
    }
}
