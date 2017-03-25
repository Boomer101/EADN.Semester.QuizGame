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
    public class QuestionRepository : IRepository<Common.Question, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Models.Question> dbSet;
        public QuestionRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Models.Question>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Question, Models.Question>().MaxDepth(1)
                    .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
                cfg.CreateMap<Models.Question, Common.Question>().MaxDepth(1)
                    .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
                cfg.CreateMap<Common.Topic, Models.Topic>();
                cfg.CreateMap<Models.Topic, Common.Topic>();
                cfg.CreateMap<Common.Quiz, Models.Quiz>();
                cfg.CreateMap<Models.Quiz, Common.Quiz>();
                cfg.CreateMap<Common.Answer, Models.Answer>();
                cfg.CreateMap<Models.Answer, Common.Answer>();
            });
        }
        public void Create(Common.Question data)
        {
            Models.Question newQuestion = Mapper.Map<Models.Question>(data);
            dbSet.Add(newQuestion);
        }
        public Common.Question Read(Guid key)
        {
            Models.Question question = dbSet.Find(key);
            return Mapper.Map<Common.Question>(question);
        }
        public void Update(Common.Question data)
        {
            // Mapping
            Models.Question updateQuestion = Mapper.Map<Models.Question>(data);
            List<Models.Topic> updateTopics = Mapper.Map<List<Models.Topic>>(data.Topics);
            List<Models.Quiz> updateQuizzes = Mapper.Map<List<Models.Quiz>>(data.Quizzes);
            List<Models.Answer> updateAnswers = Mapper.Map<List<Models.Answer>>(data.Answers);

            // Update
            updateQuestion = dbSet.Find(data.Id);
            updateQuestion.Name = data.Name;
            updateQuestion.Text = data.Text;
            updateQuestion.Quizzes = UpdateQuizzesList(updateQuestion, updateQuizzes);
            updateQuestion.Topics = UpdateTopicList(updateQuestion, updateTopics);
            updateQuestion.Answers = UpdateAnswerList(updateQuestion, updateAnswers);

            dbSet.Attach(updateQuestion);
            context.Entry(updateQuestion).State = EntityState.Modified;
        }
        public void Delete(Guid key)
        {
            Models.Question deleteQuestion = dbSet.Find(key);
            context.Answers.RemoveRange(deleteQuestion.Answers);
            dbSet.Remove(deleteQuestion);
        }

        public List<Question> GetAll()
        {
            List<Models.Question> allQuestions = dbSet.ToList();
            return Mapper.Map<List<Models.Question>, List<Common.Question>>(allQuestions);
        }
        public IEnumerable<Common.Question> GetAllQuestions()
        {
            List<Models.Question> allQuestions = dbSet.ToList();
            return Mapper.Map<List<Models.Question>,IEnumerable<Common.Question>>(allQuestions);
        }

        #region private methods
        private ICollection<Models.Quiz> UpdateQuizzesList(Models.Question data, List<Models.Quiz> newList)
        {
            List<Models.Quiz> combinedModels = data.Quizzes.ToList();
            combinedModels.AddRange(newList);

            List<Guid> localIDs = data.Topics.Select(l => l.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            var newIDs = new HashSet<Guid>(newGuidList);
            var combinedIDs = localIDs.Union(new HashSet<Guid>(newIDs));
            var results = new HashSet<Models.Quiz>();

            foreach (Guid item in combinedIDs)
            {
                if (combinedModels.Exists(l => l.Id == item))
                {
                    results.Add(combinedModels.Find(l => l.Id == item));
                }
            }

            return results;
        }

        private ICollection<Models.Topic> UpdateTopicList(Models.Question data, List<Models.Topic> newList)
        {
            List<Models.Topic> combinedModels = data.Topics.ToList();
            combinedModels.AddRange(newList);

            List<Guid> localIDs = data.Topics.Select(l => l.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            var newIDs = new HashSet<Guid>(newGuidList);
            var combinedIDs = localIDs.Union(new HashSet<Guid>(newIDs));
            var results = new HashSet<Models.Topic>();

            foreach (Guid item in combinedIDs)
            {
                if (combinedModels.Exists(l =>l.Id == item))
                {
                    results.Add(combinedModels.Find(l =>l.Id == item));
                }
            }

            return results;
        }
        private ICollection<Models.Answer> UpdateAnswerList(Models.Question data, List<Models.Answer> newList)
        {
            List<Models.Answer> combinedModels = data.Answers.ToList();
            combinedModels.AddRange(newList);

            List<Guid> localIDs = data.Topics.Select(l => l.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            var newIDs = new HashSet<Guid>(newGuidList);
            var combinedIDs = localIDs.Union(new HashSet<Guid>(newIDs));
            var results = new HashSet<Models.Answer>();

            foreach (Guid item in combinedIDs)
            {
                if (combinedModels.Exists(l => l.Id == item))
                {
                    results.Add(combinedModels.Find(l => l.Id == item));
                }
            }

            return results;
        }
        #endregion
    }
}
