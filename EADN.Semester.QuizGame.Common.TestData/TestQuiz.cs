using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.TestData
{
    public class TestQuiz
    {
        Quiz quizTestObject;
        Question quizQuestion;
        Answer quizAnswer;
        Topic quizTopic;
        //List<Topic> topicList;

        Guid topicGuid = Guid.NewGuid();

        public TestQuiz()
        {
            // Arrange Test objects
            quizTestObject = new Quiz()
            {
                Id = Guid.NewGuid(),
                Name = "Quiz 1",
                Questions = new List<Question>(),
                QuizType = QuizType.YesOrNo
            };
            quizQuestion = new Question()
            {
                Id = Guid.NewGuid(),
                Topics = new List<Topic>(),
                Answers = new List<Answer>(),
                Name = "Question 1",
                Text = "What is 1+1 ?"
            };
            quizAnswer = new Answer()
            {
                Id = Guid.NewGuid(),
                Name = "Answer 1",
                AnswerText = "2",
                IsCorrect = true
            };
            quizTopic = new Topic()
            {
                Id = topicGuid,
                Name = $"Topic-{topicGuid.ToString().Substring(0, 4)}",
                //Name = "Topic 1",
                Text = $"TopicText-{topicGuid.ToString().Substring(0, 4)}",
                //Text = "Trivial"
                //Questions = new List<Question>()
                //{
                //    quizQuestion
                //}
            };

            quizTestObject.Questions.Add(quizQuestion);
            quizTestObject.Questions[0].Topics.Add(quizTopic);
            quizTestObject.Questions[0].Answers.Add(quizAnswer);
        }

        public Quiz GetTestData()
        {
            return quizTestObject;
        }
    }
}
