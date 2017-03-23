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

        IRepository<Common.Answer, Guid> answerRepo;
        static Common.Answer testAnswer;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testAnswer = new Common.TestData.TestQuiz().GetTestData().Questions[0].Answers[0];
        }

        [TestMethod]
        public void CreateAndUpdateAnswerTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            Common.Answer updateAnswer;
            Common.Answer readAnswer;
            string updateText = "_Update";

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepo = DAL.GetAnswerRepository();
                answerRepo.Create(testAnswer);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepo = DAL.GetAnswerRepository();
                updateAnswer = answerRepo.Read(testAnswer.Id);
                updateAnswer.AnswerText = updateAnswer.AnswerText + updateText;
                updateAnswer.Name = updateAnswer.Name + updateText;
                answerRepo.Update(updateAnswer);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepo = DAL.GetAnswerRepository();
                readAnswer = answerRepo.Read(updateAnswer.Id);
            }

            // Assert
            Assert.AreEqual(testAnswer.Id, readAnswer.Id);
            Assert.IsTrue(readAnswer.Name.Contains(updateText));
            Assert.IsTrue(readAnswer.AnswerText.Contains(updateText));
        }

        [TestMethod]
        public void CreateAndDeleteAnswerTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            Common.Answer deleteAnswer = null;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepo = DAL.GetAnswerRepository();
                answerRepo.Create(testAnswer);
                DAL.Save();

                answerRepo.Delete(testAnswer.Id);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepo = DAL.GetAnswerRepository();
                deleteAnswer = answerRepo.Read(testAnswer.Id);
            }

            // Assert
            Assert.IsNull(deleteAnswer);
        }
    }
}
