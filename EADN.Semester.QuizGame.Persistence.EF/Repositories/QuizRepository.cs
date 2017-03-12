using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;
using EADN.Semester.QuizGame.Common;
using System.Data.Entity;
using AutoMapper;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;

namespace EADN.Semester.QuizGame.Persistence.EF.Repositories
{
    public class QuizRepository : IQuizRepository<Common.Quiz, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Quiz> dbSet;
        public QuizRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Quiz>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Quiz, Quiz>();
                cfg.CreateMap<Quiz, Common.Quiz>()
                    //.ForMember(dest => dest.QuizType, opt => opt.MapFrom(src => src.QuizType))
                    //.ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
                    .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                    .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            });
        }
        public void Create(Common.Quiz data)
        {
            Quiz newQuiz = Mapper.Map<Quiz>(data);
            dbSet.Add(newQuiz);
        }
        public Common.Quiz Read(Guid key)
        {
            Quiz quiz = dbSet.Find(key);
            return Mapper.Map<Common.Quiz>(quiz);
        }
        public void Update(Common.Quiz data)
        {
            // Mapping
            Quiz updateQuiz = Mapper.Map<Quiz>(data);
            Question updateQuestion = Mapper.Map<Question>(data.Question);
            List<Answer> updateAnswersList = Mapper.Map<List<Answer>>(data.Answers);
            //HashSet<Topic> updateTopicsList = Mapper.Map<HashSet<Topic>>(data.Topics);
            Models.QuizType updateQuizType = Mapper.Map<Models.QuizType>(data.QuizType);

            // Update Question
            updateQuiz = dbSet.Find(data.Id);
            updateQuiz.QuizType = updateQuizType;
            updateQuiz.Question = updateQuestion;
            updateQuiz.Answers = updateAnswersList;
            //updateQuiz.Topics = updateTopicsList;
        }
        public void Delete(Guid key)
        {
            Quiz deleteQuiz = dbSet.Find(key);
            dbSet.Remove(deleteQuiz);
        }
    }
}
