using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;
using System.ServiceModel;
using EADN.Semester.QuizGame.GameLogic;
using EADN.Semester.QuizGame.Common.GameLogicContracts;

namespace EADN.Semester.QuizGame.Communication.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AdminService : IQuizAdminService, IQuestionAdminService, IAnswerAdminService, ITopicAdminService
    {
        private IQuizGameExceptionHandler exceptionHandler;

        ITopicLogic topicAdminLogic;
        IQuizLogic quizLogic;
        IQuestionLogic questionLogic;
        IAnswerLogic answerLogic;

        public AdminService()
        {
            exceptionHandler = new FaultExceptionHandler();

            topicAdminLogic = new AdminLogic();
            quizLogic = new AdminLogic();
            questionLogic = new AdminLogic();
            answerLogic = new AdminLogic();
        }

        #region Quiz
        public void CreateQuiz(Quiz newQuiz)
        {
            try
            {
                quizLogic.CreateQuiz(newQuiz);
            }
            catch (Exception ex)
            {
               throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(newQuiz.ToString(),ex));
            }
        }

        public void CreateQuiz(Quiz newQuiz, Question newQuestion, List<Answer> newAnswers)
        {
            try
            {
                quizLogic.CreateQuiz(newQuiz, newQuestion, newAnswers);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(newQuiz.ToString(), ex));
            }
        }
        public Quiz GetQuiz(Guid id)
        {
            Quiz quiz;

            try
            {
                quiz = quizLogic.GetQuiz(id);
                return quiz;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public void UpdateQuiz(Quiz quiz)
        {
            try
            {
                quizLogic.UpdateQuiz(quiz);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(quiz.ToString(), ex));
            }
        }

        public void DeleteQuiz(Guid id)
        {
            try
            {
                quizLogic.DeleteQuiz(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        #endregion

        #region Question
        public void CreateQuestion(Question newQuestion)
        {
            try
            {
                questionLogic.CreateQuestion(newQuestion);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(newQuestion.Name, ex));
            }
        }
        public Question GetQuestion(Guid id)
        {
            Common.Question question;

            try
            {
                question = questionLogic.GetQuestion(id);
                return question;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public List<Question> GetAllQuestions()
        {
            List<Common.Question> allQuestions;

            try
            {
                allQuestions = questionLogic.GetAllQuestions();
                return allQuestions;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public void UpdateQuestion(Question question)
        {
            try
            {
                questionLogic.UpdateQuestion(question);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }

        public void DeleteQuestion(Guid id)
        {
            try
            {
                questionLogic.DeleteQuestion(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        #endregion

        #region Answer
        public void CreateAnswer(Answer newAnswer)
        {
            answerLogic.CreateAnswer(newAnswer);
        }

        public Answer GetAnswer(Guid id)
        {
            Answer answer;
            try
            {
                answer = answerLogic.GetAnswer(id);
                return answer;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }

        public List<Answer> GetAllAnswers()
        {
            List<Answer> allAnswers;

            try
            {
                allAnswers = answerLogic.GetAllAnswers();
                return allAnswers;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public void UpdateAnswer(Answer answer)
        {
            try
            {
                answerLogic.UpdateAnswer(answer);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(answer.Name, ex));
            }
        }

        public void DeleteAnswer(Guid id)
        {
            try
            {
                answerLogic.DeleteAnswer(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        #endregion

        #region Topic
        public void CreateTopic(Topic topic)
        {
            try
            {
                topicAdminLogic.CreateTopic(topic);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(topic.ToString(), ex));
            }
        }
        public Topic GetTopic(Guid id)
        {
            Common.Topic topic;

            try
            {
                topic = topicAdminLogic.GetTopic(id);
                return topic;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public List<Topic> GetAllTopics()
        {
            List<Topic> topics;

            try
            {
                topics = topicAdminLogic.GetAllTopics();
                return topics;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public void UpdateTopic(Topic topic)
        {
            try
            {
                topicAdminLogic.UpdateTopic(topic);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public void DeleteTopic(Guid id)
        {
            try
            {
                topicAdminLogic.DeleteTopic(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        #endregion
    }
}
