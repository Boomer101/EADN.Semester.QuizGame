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
        List<Topic> topicList;

        public TestQuiz()
        {
            // Arrange Test objects
            quizTestObject = new Quiz()
            {
                Id = Guid.NewGuid(),
                Name = "Question 1",
                Answers = new List<Answer>(),
                QuizType = QuizType.YesOrNo
            };
            quizQuestion = new Question()
            {
                Id = Guid.NewGuid(),
                Topics = new List<Topic>(),
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
                Id = Guid.NewGuid(),
                Name = "Topic 1",
                Text = "Trivial"
            };

            quizTestObject.Question = quizQuestion;
            quizTestObject.Question.Topics.Add(quizTopic);
            quizTestObject.Answers.Add(quizAnswer);
        }

        public Quiz GetTestData()
        {
            return quizTestObject;
        }
    }
}
