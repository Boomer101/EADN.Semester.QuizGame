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
                cfg.CreateMap<Quiz, Common.Quiz>();
                cfg.CreateMap<Common.Question, Question>().MaxDepth(2);
                cfg.CreateMap<Question, Common.Question>().MaxDepth(2);
                cfg.CreateMap<Common.Answer, Answer>();
                cfg.CreateMap<Common.Topic, Topic>();
                cfg.CreateMap<Answer, Common.Answer>();
                cfg.CreateMap<Topic, Common.Topic>();
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
            //if(quiz != null)
            //{
            //    context.Entry(quiz.Questions).Collection(q => q).Load();
            //    //context.Entry(quiz.Questions).Collection(q => q.Top).Load();
            //}

            return Mapper.Map<Common.Quiz>(quiz);
        }
        public void Update(Common.Quiz data)
        {
            Quiz updateQuiz = dbSet.Find(data.Id);

            // Mapping
            Quiz updateQuizData = Mapper.Map<Quiz>(data);
            List<Question> updateQuestionsList = Mapper.Map<List<Question>>(data.Questions);
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
            Quiz deleteQuiz = dbSet.Find(key);
            dbSet.Remove(deleteQuiz);
        }

        private ICollection<Question> UpdateList(Quiz data, List<Question> newList)
        {
            ICollection<Question> questions = data.Questions;
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
        }
    }
}
