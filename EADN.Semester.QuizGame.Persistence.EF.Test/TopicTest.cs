using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class TopicTest
    {
        IPersistence persistenceFactory;
        IData DAL;

        IRepository<Common.Topic, Guid> topicRepo;

        static Common.Topic testTopic;
        static string topicName;
        static string topicText;
        static Guid testKey = new Guid("00000000-0000-0000-0000-000000000000");

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testTopic = new Common.TestData.TestQuiz().GetTestData().Question.Topics[0];
            topicName = testTopic.Name;
            topicText = testTopic.Text;
        }

        [TestMethod]
        public void ReadTopicTest()
        {
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");

            // Act
            using(DAL = persistenceFactory.GetDataAccesLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                testTopic = topicRepo.Read(testKey);
            }

            // Assert
            Assert.AreEqual(testTopic.Id, testKey);
        }

        [TestMethod]
        public void CreateAndReadTopicTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Topic readTopic;

            // Act
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicRepo.Create(testTopic);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                readTopic = topicRepo.Read(testTopic.Id);
            }

            // Assert
            Assert.AreEqual(testTopic.Id, readTopic.Id);
            Assert.AreEqual(testTopic.Name, readTopic.Name);
            Assert.AreEqual(testTopic.Text, readTopic.Text);
        }

        [TestMethod]
        public void UpdateTopicTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Topic readTopic;
            Common.Topic updateTopic;

            // Act
            using (DAL = persistenceFactory.GetDataAccesLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                readTopic = topicRepo.Read(testKey);
                readTopic.Name = "Topic 2";
                readTopic.Text = "Topic 2 Text";
                topicRepo.Update(readTopic);
                DAL.Save();
            }

            using(DAL = persistenceFactory.GetDataAccesLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                updateTopic = topicRepo.Read(testKey);
            }

            // Assert
            Assert.AreEqual(readTopic.Id, updateTopic.Id);
            Assert.AreEqual(readTopic.Name, updateTopic.Name);
            Assert.AreEqual(readTopic.Text, updateTopic.Text);
        }
    }
}
