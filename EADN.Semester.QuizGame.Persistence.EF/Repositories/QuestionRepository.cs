using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;
using AutoMapper;
using System.Data.Entity;

namespace EADN.Semester.QuizGame.Persistence.EF.Repositories
{
    public class QuestionRepository : IQuestionRepository<Common.Question, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Question> dbSet;
        public QuestionRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Question>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Question, Question>()
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
                cfg.CreateMap<Question, Common.Question>()
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
                cfg.CreateMap<Common.Topic, Topic>();
                cfg.CreateMap<Topic, Common.Topic>();
            });
        }
        public void Create(Common.Question data)
        {
            Question newQuestion = Mapper.Map<Question>(data);
            dbSet.Add(newQuestion);
        }
        public Common.Question Read(Guid key)
        {
            Question question = dbSet.Find(key);
            context.Entry(question).Collection(q => q.Topics).Load();

            return Mapper.Map<Common.Question>(question);
        }
        public void Update(Common.Question data)
        {
            // Mapping
            Question updateQuestion = Mapper.Map<Question>(data);
            HashSet<Topic> updateTopics = Mapper.Map<HashSet<Topic>>(data.Topics);

            // Update
            updateQuestion = dbSet.Find(data.Id);
            updateQuestion.Name = data.Name;
            updateQuestion.Text = data.Text;
            updateQuestion.Topics = updateTopics;
        }
        public void Delete(Guid key)
        {
            Question deleteQuestion = dbSet.Find(key);
            dbSet.Remove(deleteQuestion);
        }

        public IEnumerable<Common.Question> GetAll()
        {
            List<Question> allQuestion = dbSet.ToList();
            return Mapper.Map<List<Question>,IEnumerable<Common.Question>>(allQuestion);
        }
    }
}
