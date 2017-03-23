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
        public void CreateAndDeleteQuizTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            Common.Quiz readQuiz;
            Common.Quiz deleteQuiz = null;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                quizRepo.Create(testQuiz);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                quizRepo.Delete(testQuiz.Id);
                DAL.Save();

                deleteQuiz = quizRepo.Read(testQuiz.Id);
            }

            // Assert
            Assert.IsTrue(deleteQuiz == null, $"Quiz {deleteQuiz} was not deleted !");
        }

        [TestMethod]
        public void CreateUpdateReadQuizTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            Common.Quiz updateQuiz = null;
            Common.Quiz readQuiz = null;
            string updateText = "_UPDATE";

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                quizRepo.Create(testQuiz);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                updateQuiz = quizRepo.Read(testQuiz.Id);
                updateQuiz.Name = updateQuiz.Name + updateText;
                updateQuiz.QuizType = QuizType.MultipleChoice;

                quizRepo.Update(updateQuiz);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepo = DAL.GetQuizRepository();
                readQuiz = quizRepo.Read(testQuiz.Id);
            }

            // Assert
            Assert.AreEqual(testQuiz.Id, readQuiz.Id);
            Assert.IsTrue(readQuiz.Name.Contains(updateText));
            Assert.IsTrue(readQuiz.QuizType != testQuiz.QuizType);
        }
    }
}
