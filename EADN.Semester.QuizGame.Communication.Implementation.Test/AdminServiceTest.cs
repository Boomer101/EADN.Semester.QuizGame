using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using TestData = EADN.Semester.QuizGame.Common.TestData;
using EADN.Semester.QuizGame.Communication.Implementation;
using System.Collections.Generic;

namespace EADN.Semester.QuizGame.Communication.Implementation.Test
{
    [TestClass]
    public class AdminServiceTest
    {
        IQuizAdminService quizAdminService;
        ITopicAdminService topicAdminService;
        IQuestionAdminService questionAdminService;
        IAnswerAdminService answerAdminService;

        static Common.Quiz quiz;
        static Common.Topic topic;
        static Common.Question question;
        static Common.Answer answer;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            quiz = new TestData.TestQuiz().GetTestData();
        }

        [TestMethod]
        public void CreateAndReadNewQuizTest()
        {
            // Arrange
            Common.Quiz readQuiz;
            quizAdminService = new AdminService();

            // Act
            quizAdminService.CreateQuiz(quiz);
            readQuiz = quizAdminService.GetQuiz(quiz.Id);

            // Assert
            Assert.IsNotNull(readQuiz);
            Assert.AreEqual(quiz.Id, readQuiz.Id);
        }

        [TestMethod]
        public void CreateAndDeleteQuizTest()
        {
            // Arrange
            Common.Quiz readQuiz;
            quizAdminService = new AdminService();

            // Act
            quizAdminService.CreateQuiz(quiz);
            readQuiz = quizAdminService.GetQuiz(quiz.Id);

            // Assert
            Assert.IsNotNull(readQuiz);
            Assert.AreEqual(quiz.Id, readQuiz.Id);

            // Act
            quizAdminService.DeleteQuiz(quiz.Id);
            readQuiz = quizAdminService.GetQuiz(quiz.Id);

            // Assert
            Assert.IsNull(readQuiz);
        }

        [TestMethod]
        public void GetAllTopics()
        {
            // Arrange
            List<Common.Topic> topics = new List<Common.Topic>();
            topicAdminService = new AdminService();

            // Act
            topics = topicAdminService.GetAllTopics();

            // Assert
            Assert.IsTrue(topics.Count >= 1);
        }
    }
}
