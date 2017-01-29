using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace EADN.Semester.Quiz.Persistence.Test
{
    /// <summary>
    /// Summary description for AutoMapperTest
    /// </summary>
    [TestClass]
    public class AutoMapperTest
    {
        [TestInitialize]
        public void InitTest()
        { }

        [TestMethod]
        public void AutoMapIsValid()
        {
            // Act
            AutoMapperConfiguration.Configure();
            var config = AutoMapperConfiguration.Config;

            // Assert
            try
            {
                config.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException ex)
            {
                Assert.IsNull(ex,$"AutoMapperException was thrown: {ex.Message}");
            }
        }
    }
}
