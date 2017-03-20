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
            // Simulate Factory iteration -> Common AssemblyFactory
            CustomAssemblySection configSection = (CustomAssemblySection)ConfigurationManager.GetSection("customAssemblySection");
            CustomAssemblyConfigElement IPersistenceAssembly = new CustomAssemblyConfigElement();
            foreach (CustomAssemblyConfigElement item in configSection.ConfigElementCollection)
            {
                if (item.Key.Equals("IPersistence")){
                    IPersistenceAssembly = item;
                }
            }

            IPersistence persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(IPersistenceAssembly.Dir, IPersistenceAssembly.Dll);
            //IPersistence persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
            var DAL = persistenceFactory.GetDataAccessLayer();
            var topicRepo = DAL.GetTopicRepository();

            // Assert
            Assert.IsTrue(DAL.GetTopicRepository().Equals(topicRepo));
        }
    }
}
