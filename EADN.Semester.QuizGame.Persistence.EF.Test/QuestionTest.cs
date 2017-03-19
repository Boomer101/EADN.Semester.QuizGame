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
            testQuestion = new TestData.TestQuiz().GetTestData().Questions[0];
        }

        [TestMethod]
        public void CreateAndReadQuestionTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Question readQuestion;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Create(testQuestion);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
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
        public void CreateAndUpdateQuestionTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Question updateQuestion = null;
            string updateText = "_UPDATE";

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Create(testQuestion);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                updateQuestion = questionRepo.Read(testQuestion.Id);
                updateQuestion.Name = updateQuestion.Name + updateText;
                updateQuestion.Text = updateQuestion.Text + updateText;

                questionRepo.Update(updateQuestion);
                DAL.Save();
            }

            // Assert
            Assert.AreEqual(testQuestion.Id, updateQuestion.Id);
            Assert.IsTrue(updateQuestion.Name.Contains(updateText));
            Assert.IsTrue(updateQuestion.Text.Contains(updateText));
        }

        [TestMethod]
        public void CreateAndDeleteQuestionTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Question deletedQuestion = null;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Create(testQuestion);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepo = DAL.GetQuestionRepository();
                questionRepo.Delete(testQuestion.Id);
                DAL.Save();

                deletedQuestion =  questionRepo.Read(testQuestion.Id);
            }

            // Assert
            Assert.IsTrue(deletedQuestion == null, $"Question {deletedQuestion} was not deleted !");
        }
    }
}
