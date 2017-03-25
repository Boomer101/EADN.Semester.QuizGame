using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Repositories;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class UnitOfWork : IData
    {
        private QuizGameContext context = new QuizGameContext();

        private IRepository<Topic, Guid> topicRepository;
        private IRepository<Quiz,Guid> quizRepository;
        private IRepository<Question,Guid> questionRepository;
        private IRepository<Answer,Guid> answerRepository;

        //static UnitOfWork()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Common.Topic, Topic>();
        //        cfg.CreateMap<Topic, Common.Topic>();
        //        //cfg.CreateMap<Common.Quiz, Quiz>();
        //        //cfg.CreateMap<Quiz, Common.Quiz>();
        //    });
        //}
        public IRepository<Common.Quiz, Guid> GetQuizRepository()
        {
            if (quizRepository == null)
            {
                quizRepository = new QuizRepository(context);
            }

            return quizRepository;
        }
        public IRepository<Common.Topic, Guid> GetTopicRepository()
        {
            if(topicRepository == null)
            {
                topicRepository = new TopicRepository(context);
            }

            return topicRepository;
        }
        public IRepository<Common.Question, Guid> GetQuestionRepository()
        {
            if (questionRepository == null)
            {
                questionRepository = new QuestionRepository(context);
            }

            return questionRepository;
        }
        public IRepository<Common.Answer, Guid> GetAnswerRepository()
        {
            if(answerRepository == null)
            {
                answerRepository = new AnswerRepository(context);
            }

            return answerRepository;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
