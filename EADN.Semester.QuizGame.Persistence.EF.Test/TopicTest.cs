using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;
using System.Collections.Generic;

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

        [ClassInitialize]
        public static void InitTestClass(TestContext context)
        {
            testTopic = new Common.TestData.TestQuiz().GetTestData().Questions[0].Topics[0];
            topicName = testTopic.Name;
            topicText = testTopic.Text;
        }

        [TestMethod]
        public void CreateAndReadTopicTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Topic readTopic;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicRepo.Create(testTopic);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
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
        public void CreateAndUpdateTopicTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Topic updateTopic;
            Common.Topic readTopic;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicRepo.Create(testTopic);
                DAL.Save();
            }

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                updateTopic = topicRepo.Read(testTopic.Id);
                updateTopic.Name = "Topic 2";
                updateTopic.Text = "Topic 2 Text";
                topicRepo.Update(updateTopic);
                DAL.Save();
            }

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                readTopic = topicRepo.Read(updateTopic.Id);
            }

            // Assert
            Assert.AreEqual(readTopic.Id, updateTopic.Id);
            Assert.AreEqual(readTopic.Name, updateTopic.Name);
            Assert.AreEqual(readTopic.Text, updateTopic.Text);
        }

        [TestMethod]
        public void CreateAndDeleteTopicTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            Common.Topic deleteTopic = null;

            // Act
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicRepo.Create(testTopic);
                DAL.Save();
            }
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicRepo.Delete(testTopic.Id);
                DAL.Save();

                deleteTopic = topicRepo.Read(testTopic.Id);
            }

            // Assert
            Assert.IsTrue(deleteTopic == null, $"Quiz {deleteTopic} was not deleted !");
        }

        [TestMethod]
        public void GetAllTopicsTest()
        {
            // Arrange
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            List<Common.Topic> topicsList = new List<Common.Topic>();

            using(DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepo = DAL.GetTopicRepository();
                topicsList = topicRepo.GetAll();
            }

            // Assert
            Assert.IsTrue(topicsList.Count >= 1);
        }
    }
}
