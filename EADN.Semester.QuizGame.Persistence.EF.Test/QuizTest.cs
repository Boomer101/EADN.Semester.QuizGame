using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using TestData = EADN.Semester.QuizGame.Common.TestData;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class QuizTest
    {
        IPersistence persistenceFactory;
        IData DAL;

        IRepository<Common.Quiz, Guid> quizRepo;

        static Common.Quiz testQuiz;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testQuiz = new TestData.TestQuiz().GetTestData();
        }

        [TestMethod]
        public void CreateAndReadQuizTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Quiz readQuiz;

            // Act
            using(DAL = persistenceFactory.GetDataAccesLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                quizRepo.Create(testQuiz);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                readQuiz = quizRepo.Read(testQuiz.Id);
            }

            // Assert
            Assert.AreEqual(testQuiz.Id, readQuiz.Id);
            Assert.AreEqual(testQuiz.Name, readQuiz.Name);
            Assert.AreEqual(testQuiz.QuizType, readQuiz.QuizType);
            Assert.AreEqual(testQuiz.Answers.Count, readQuiz.Answers.Count);
            Assert.AreEqual(testQuiz.Question.Topics.Count, readQuiz.Question.Topics.Count);
        }
    }
}
