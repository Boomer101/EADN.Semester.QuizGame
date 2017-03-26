using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Common.GameLogicContracts;
using System.Transactions;

namespace EADN.Semester.QuizGame.GameLogic
{
    public class AdminLogic : ITopicLogic, IQuestionLogic, IAnswerLogic, IQuizLogic
    {
        private IPersistence persistenceFactory;
        private IData DAL;

        private IRepository<Common.Quiz, Guid> quizRepository;
        private IRepository<Common.Question, Guid> questionRepository;
        private IRepository<Common.Answer, Guid> answerRepository;
        private IRepository<Common.Topic, Guid> topicRepository;

        public AdminLogic()
        {
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>();
        }

        #region TopicLogic
        public void CreateTopic(Topic topic)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topicRepository.Create(topic);
                DAL.Save();
            }
        }

        public Topic GetTopic(Guid id)
        {
            Topic topic = null;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topic = topicRepository.Read(id);  
            }

            return topic;
        }
        public List<Topic> GetAllTopics()
        {
            List<Common.Topic> topics;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topics = topicRepository.GetAll();
               
            }

            return topics;
        }

        public void UpdateTopic(Topic topic)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topicRepository.Update(topic);
                DAL.Save();
            }
        }

        public void DeleteTopic(Guid id)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topicRepository.Delete(id);
                DAL.Save();
            }
        }

        public Topic CreateTopicAndSendBack(Topic topic)
        {
            throw new NotImplementedException();
            
            // Future use
            Topic newTopic;
            
            using(TransactionScope scope =new TransactionScope())
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    topicRepository = DAL.GetTopicRepository();
                    topicRepository.Create(topic);
                    DAL.Save();
                }
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    topicRepository = DAL.GetTopicRepository();
                    newTopic = topicRepository.Read(topic.Id);
                }
            }

            return newTopic;
        }
        #endregion

        #region QuizLogic
        public void CreateQuiz(Quiz newQuiz)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quizRepository.Create(newQuiz);
                DAL.Save();
            }
        }

        public void CreateQuiz(Quiz newQuiz, Question newQuestion, List<Answer> newAnswers)
        {
            newQuestion.Answers = newAnswers;
            newQuiz.Questions.Add(newQuestion);

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quizRepository.Create(newQuiz);
                DAL.Save();
            }
        }

        public Quiz GetQuiz(Guid id)
        {
            Quiz quiz = null;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quiz = quizRepository.Read(id);
            }

            return quiz;
        }

        public void UpdateQuiz(Quiz quiz)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quizRepository.Update(quiz);
                DAL.Save();
            }
        }

        public void DeleteQuiz(Guid id)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quizRepository.Delete(id);
                DAL.Save();
            }
        }
        #endregion

        #region QuestionLogic
        public void CreateQuestion(Question newQuestion)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepository = DAL.GetQuestionRepository();
                questionRepository.Create(newQuestion);
                DAL.Save();
            }
        }

        public Question GetQuestion(Guid id)
        {
            Question question;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepository = DAL.GetQuestionRepository();
                question = questionRepository.Read(id);
            }

            return question;
        }

        public List<Question> GetAllQuestions()
        {
            List<Common.Question> allQuestions = new List<Question>();

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepository = DAL.GetQuestionRepository();
                allQuestions = questionRepository.GetAll();
            }

            return allQuestions;
        }

        public void UpdateQuestion(Question question)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepository = DAL.GetQuestionRepository();
                questionRepository.Update(question);
                DAL.Save();
            }
        }

        public void DeleteQuestion(Guid id)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                questionRepository = DAL.GetQuestionRepository();
                questionRepository.Delete(id);
                DAL.Save();
            }
        }
        #endregion

        #region AnswerLogic
        public void CreateAnswer(Answer newAnswer)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepository = DAL.GetAnswerRepository();
                answerRepository.Create(newAnswer);
                DAL.Save();
            }
        }

        public Answer GetAnswer(Guid id)
        {
            Answer answer;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepository = DAL.GetAnswerRepository();
                answer = answerRepository.Read(id);
            }

            return answer;
        }

        public List<Answer> GetAllAnswers()
        {
            List<Answer> answers;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepository = DAL.GetAnswerRepository();
                answers = answerRepository.GetAll();
            }

            return answers;
        }

        public void UpdateAnswer(Answer answer)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepository = DAL.GetAnswerRepository();
                answerRepository.Update(answer);
                DAL.Save();
            }
        }

        public void DeleteAnswer(Guid id)
        {
            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                answerRepository = DAL.GetAnswerRepository();
                answerRepository.Delete(id);
                DAL.Save();
            }
        }
        #endregion
    }
}
