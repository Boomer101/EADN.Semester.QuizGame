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
    public class AdminLogic : IAdminLogic, ITopicLogic
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
                return topic;
            }
        }
        public List<Topic> GetAllTopics()
        {
            List<Common.Topic> topics;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                topicRepository = DAL.GetTopicRepository();
                topics = topicRepository.GetAll();
                return topics;
            }
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
    }
}
