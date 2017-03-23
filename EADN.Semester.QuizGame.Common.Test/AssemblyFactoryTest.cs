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
            // Arrange
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
            // Arrange
            string typeName = "EADN.Semester.QuizGame.Persistence.EF.PersistenceFactory";

            // Act
            var instance = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");

            // Assert
            Assert.IsTrue(instance.GetType().FullName.Equals(typeName));
        }

        [TestMethod]
        public void LoadIPersistenceViaConfigTest()
        {
            // Arrange
            string typeName = "EADN.Semester.QuizGame.Persistence.EF.PersistenceFactory";

            // Act
            var instance = AssemblyFactory.LoadInstance<IPersistence>();

            // Assert
            Assert.IsTrue(instance.GetType().FullName.Equals(typeName));
        }
    }
    public class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}