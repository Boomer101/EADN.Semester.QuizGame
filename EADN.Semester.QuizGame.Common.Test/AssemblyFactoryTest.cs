using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EADN.Semester.QuizGame.Common.Test
{
    [TestClass]
    public class AssemblyFactoryTest
    {
        [TestMethod]
        public void LoadAssemblyTest()
        {
            string typeName = "EADN.Semester.QuizGame.Common.Test.TestObject";

            // Act
            var instance = AssemblyFactory.LoadInstance<EADN.Semester.QuizGame.Common.Test.TestObject>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Common.Test.dll");

            // Assert
            Assert.IsTrue(instance.GetType().FullName.Equals(typeName));
            Assert.IsTrue(instance.GetType().GetProperties().Length == 2);
        }

        [TestMethod]
        public void LoadInterfaceImplementationTest()
        {
            string typeName = "EADN.Semester.QuizGame.Persistence.EF.PersistenceFactory";

            // Act
            var instance = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");

            // Assert
            Assert.IsTrue(instance.GetType().FullName.Equals(typeName));
        }

        [TestMethod]
        public void LoadEFAssemblyTest()
        {
            string typeName = "EADN.Semester.QuizGame.Persistence.EF.TopicRepository";

            // Act
            var instance = AssemblyFactory.LoadInstance<EADN.Semester.QuizGame.Persistence.EF.TopicRepository>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");

            // Assert
            Guid key = new Guid("00000000-0000-0000-0000-000000000000");
            Assert.IsTrue(instance.GetType().FullName.Equals(typeName));
            Assert.IsTrue(instance.Read(key).Id.Equals(key));
        }

    }
    public class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TestObject()
        { }
    }
}