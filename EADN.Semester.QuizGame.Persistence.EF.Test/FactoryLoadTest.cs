using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence;

namespace EADN.Semester.QuizGame.Persistence.EF.Test
{
    [TestClass]
    public class FactoryLoadTest
    {
        [TestMethod]
        public void PersistenceFactoryTest()
        {
            IPersistence persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            var DAL = persistenceFactory.GetDataAccesLayer();
            var topicRepo = DAL.GetTopicRepository();

            // Assert
            Assert.IsTrue(DAL.GetTopicRepository().Equals(topicRepo));
        }
    }
}
