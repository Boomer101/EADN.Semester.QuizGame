using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common.GameLogicContracts;
using EADN.Semester.QuizGame.Common;
using TestData = EADN.Semester.QuizGame.Common.TestData;
using EADN.Semester.QuizGame.GameLogic;

namespace EADN.Semester.QuizGame.GameLogic.Test
{
    [TestClass]
    public class TopicLogicTest
    {
        static ITopicLogic topicLogic;
        static Topic testTopic;

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            topicLogic = new AdminLogic();
            testTopic = new TestData.TestQuiz().GetTestData().Questions[0].Topics[0];
        }


        [TestMethod]
        public void CreateAndReadTopicTest()
        {
            // Arrange
            Topic readTopic;

            // Act
            topicLogic.CreateTopic(testTopic);
            readTopic = topicLogic.GetTopic(testTopic.Id);

            // Assert
            Assert.AreEqual(testTopic.Id, readTopic.Id);
        }
    }
}
