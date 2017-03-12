using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EADN.Semester.QuizGame.Common.Test
{
    [TestClass]
    public class DataContractTest
    {
        Quiz quizTestObject;
        Question quizQuestion;
        Answer quizAnswer;
        Topic quizTopic;
        List<Topic> topicList;

        [TestInitialize]
        public void InitTest()
        {
            // Arrange Test objects
            quizTestObject = new Quiz()
            {
                Id = new Guid(),
                Name = "Question 1",
                //Topics = new HashSet<Topic>(),
                Answers = new List<Answer>()
            };
            quizQuestion = new Question()
            {
                Id = new Guid(),
                Name = "Question 1",
                Text = "What is 1+1 ?"
            };
            quizAnswer = new Answer()
            {
                Id = new Guid(),
                Name = "Answer 1",
                AnswerText = "2",
                IsCorrect = true
            };
            quizTopic = new Topic()
            {
                Id = new Guid(),
                Name = "Topic 1",
                Text = "Trivial"
            };

            quizTestObject.Question = quizQuestion;
            quizTestObject.Answers.Add(quizAnswer);
            //quizTestObject.Topics.Add(quizTopic);
        }

        [TestMethod]
        public void QuizDataContractMemoryTest()
        {
            // Act
            Quiz quizFromMemory = TestHelper.DataContractMemoryTest(quizTestObject, null);

            // Assert
            Assert.AreEqual(quizFromMemory.Id, quizTestObject.Id);
            Assert.AreEqual(quizFromMemory.Name, quizTestObject.Name);
            Assert.AreEqual(quizFromMemory.Answers[0].AnswerText, quizAnswer.AnswerText);
        }

        [TestMethod]
        public void QuizBaseDataContractMemoryTest()
        {
            List<Type> knownTypes = new List<Type>()
            {
                quizTestObject.GetType(),
                quizTopic.GetType(),
                quizQuestion.GetType(),
                quizAnswer.GetType()
            };
          
            // Act
            QuizBase quizBaseFromMemory = TestHelper.DataContractMemoryTest(quizTestObject, knownTypes);

            // Assert
            Assert.AreEqual(quizBaseFromMemory.Id, quizTestObject.Id);
            Assert.AreEqual(quizBaseFromMemory.Name, quizTestObject.Name);
        }
    }
}
