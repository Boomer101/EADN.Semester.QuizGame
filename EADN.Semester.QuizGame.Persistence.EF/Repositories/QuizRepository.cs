using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Models;
using System.Data.Entity;
using AutoMapper;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;

namespace EADN.Semester.QuizGame.Persistence.EF.Repositories
{
    public class QuizRepository : IQuizRepository<Common.Quiz, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Models.Quiz> dbSet;
        public QuizRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Models.Quiz>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Quiz, Models.Quiz>();
                cfg.CreateMap<Models.Quiz, Common.Quiz>();
                cfg.CreateMap<Common.Question, Models.Question>().MaxDepth(2);
                cfg.CreateMap<Models.Question, Common.Question>().MaxDepth(2);
                cfg.CreateMap<Common.Answer, Models.Answer>();
                cfg.CreateMap<Common.Topic, Models.Topic>();
                cfg.CreateMap<Models.Answer, Common.Answer>();
                cfg.CreateMap<Models.Topic, Common.Topic>();
            });
        }
        public void Create(Common.Quiz data)
        {
            Models.Quiz newQuiz = Mapper.Map<Models.Quiz>(data);
            dbSet.Add(newQuiz);
        }
        public Common.Quiz Read(Guid key)
        {
            Models.Quiz quiz = dbSet.Find(key);
            return Mapper.Map<Common.Quiz>(quiz);
        }
        public void Update(Common.Quiz data)
        {
            Models.Quiz updateQuiz = dbSet.Find(data.Id);

            // Mapping
            Models.Quiz updateQuizData = Mapper.Map<Models.Quiz>(data);
            List<Models.Question> updateQuestionsList = Mapper.Map<List<Models.Question>>(data.Questions);
            Models.QuizType updateQuizTypeData = Mapper.Map<Models.QuizType>(data.QuizType);

            // Update Quiz
            updateQuiz.Name = data.Name;
            updateQuiz.QuizType = updateQuizTypeData;
            updateQuiz.Questions = UpdateList(updateQuiz, updateQuestionsList);
            dbSet.Attach(updateQuiz);
            context.Entry(updateQuiz).State = EntityState.Modified;
        }
        public void Delete(Guid key)
        {
            Models.Quiz deleteQuiz = dbSet.Find(key);
            dbSet.Remove(deleteQuiz);
        }
        public IEnumerable<Common.Quiz> GetAllQuizzes()
        {
            List<Models.Quiz> allQuizzes = dbSet.ToList();
            return Mapper.Map<List<Models.Quiz>, IEnumerable<Common.Quiz>>(allQuizzes);
        }

        #region private methods
        private ICollection<Models.Question> UpdateList(Models.Quiz data, List<Models.Question> newList)
        {
            ICollection<Models.Question> questions = data.Questions;
            List<Guid> localGuidList = data.Questions.Select(q => q.Id).ToList();
            List<Guid> newGuidList = newList.Select(n => n.Id).ToList();

            foreach (var contextQuestion in context.Questions.ToList())
            {
                if (newGuidList.Contains(contextQuestion.Id))
                {
                    if (!localGuidList.Contains(contextQuestion.Id))
                    {
                        questions.Add(contextQuestion);
                    }
                }
                else
                {
                    questions.Remove(contextQuestion);
                }
            }

            return questions;

        #endregion
        }
    }
}
