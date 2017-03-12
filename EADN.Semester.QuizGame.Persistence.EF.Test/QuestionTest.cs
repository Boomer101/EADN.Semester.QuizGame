using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using TestData = EADN.Semester.QuizGame.Common.TestData;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class QuestionTest
    {
        IPersistence persistenceFactory;
        IData DAL;

        IRepository<Common.Question, Guid> questionRepo;

        static Common.Question testQuestion;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testQuestion = new TestData.TestQuiz().GetTestData().Question;
        }

        [TestMethod]
        public void CreateAndReadQuestionTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");

            // Act
            using(DAL = persistenceFactory.GetDataAccesLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Create(testQuestion);
                DAL.Save();
            }
        }
    }
}
