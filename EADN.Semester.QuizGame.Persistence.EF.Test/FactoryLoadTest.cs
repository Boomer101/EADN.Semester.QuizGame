using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence;
using System.Configuration;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class FactoryLoadTest
    {
        [TestMethod, TestCategory("Factory")]
        public void PersistenceFactoryTest()
        {
            IPersistence persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            var DAL = persistenceFactory.GetDataAccessLayer();
            var topicRepo = DAL.GetTopicRepository();

            // Assert
            Assert.IsTrue(DAL.GetTopicRepository().Equals(topicRepo));
        }
    }
}
