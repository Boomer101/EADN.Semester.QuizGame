using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizData;
using System.Collections.Generic;

namespace QuizData.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Question question1 = new Question();
            Answer answer1 = new Answer();

            Quiz quiz1 = new Quiz(question1, new List<Answer> { answer1 });

            Assert.IsTrue(quiz1.answers.Count == 1);
        }
    }
}
