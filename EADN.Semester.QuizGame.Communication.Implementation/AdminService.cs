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
        private IPersistence persistenceFactory;
        private IData DAL;
        private IQuizGameExceptionHandler exceptionHandler;

        private IRepository<Common.Quiz,Guid> quizRepository;
        private IRepository<Common.Question, Guid> questionRepository;
        private IRepository<Common.Answer, Guid> answerRepository;

        ITopicLogic topicAdminLogic;

        public AdminService()
        {
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
            exceptionHandler = new FaultExceptionHandler();

            topicAdminLogic = new AdminLogic();
        }

        #region Quiz
        public void CreateQuiz(Quiz newQuiz)
        {
            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quizRepository.Create(newQuiz);
                    DAL.Save();
                }
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
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quizRepository.Create(newQuiz);
                    DAL.Save();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(newQuiz.ToString(), ex));
            }
        }
        public Quiz GetQuiz(Guid id)
        {
            Quiz quiz = null;

            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quiz = quizRepository.Read(id);
                }

                return quiz;
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(quiz.ToString(), ex));
            }
        }
        public void UpdateQuiz(Quiz quiz)
        {
            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quizRepository.Update(quiz);
                    DAL.Save();
                };
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
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quizRepository.Delete(id);
                    DAL.Save();
                }
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
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    questionRepository = DAL.GetQuestionRepository();
                    questionRepository.Create(newQuestion);
                    DAL.Save();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public Question GetQuestion(Guid id)
        {
            Common.Question question = null;

            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    questionRepository = DAL.GetQuestionRepository();
                    question = questionRepository.Read(id);
                    return question;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(null, ex));
            }
        }
        public List<Question> GetAllQuestions()
        {
            List<Common.Question> allQuestions = new List<Question>();

            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    questionRepository = DAL.GetQuestionRepository();
                    allQuestions = questionRepository.GetAll();
                    return allQuestions;
                }
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
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    questionRepository = DAL.GetQuestionRepository();
                    questionRepository.Update(question);
                    DAL.Save();
                }
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
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    questionRepository = DAL.GetQuestionRepository();
                    questionRepository.Delete(id);
                    DAL.Save();
                }
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
            throw new NotImplementedException();
        }

        public Answer GetAnswer(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAllAnswers()
        {
            throw new NotImplementedException();
        }
        public void UpdateAnswer(Answer answer)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new FaultException<QuizGameFaultException>(exceptionHandler.CreateException(answer.ToString(), ex));
            }
        }

        public void DeleteAnswer(Guid id)
        {
            throw new NotImplementedException();
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
