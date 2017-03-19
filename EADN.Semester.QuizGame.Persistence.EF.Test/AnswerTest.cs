using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class AnswerTest
    {
        IPersistence persistenceFactory;
        IData DAL;

        IRepository<Common.Answer, Guid> quizRepo;

        static Common.Answer testAnswer;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testAnswer = new Common.TestData.TestQuiz().GetTestData().Questions[0].Answers[0];
        }

        [TestMethod]
        public void ReadAnswerTest()
        {
        }
    }
}
