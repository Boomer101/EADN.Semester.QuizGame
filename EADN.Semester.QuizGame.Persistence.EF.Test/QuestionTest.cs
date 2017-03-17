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
            Common.Question readQuestion;

            // Act
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Create(testQuestion);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                readQuestion = questionRepo.Read(testQuestion.Id);
            }

            // Assert
            Assert.AreEqual(testQuestion.Id, readQuestion.Id);
            Assert.AreEqual(testQuestion.Name, readQuestion.Name);
            Assert.AreEqual(testQuestion.Topics.Count, readQuestion.Topics.Count);
        }

        [TestMethod]
        public void ReadQuestionTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Question readQuestion;
            Guid testKey = new Guid("B06CCCEA-8D37-4C5F-9298-B29E7222CEDC");

            // Act
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                readQuestion = questionRepo.Read(testKey);
            }
        }
    }
}
