using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;
using System.Data.Entity;
using AutoMapper;

namespace EADN.Semester.QuizGame.Persistence.EF.Repositories
{
    public class AnswerRepository : IAnswerRepository<Common.Answer, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Answer> dbSet;

        public AnswerRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Answer>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Answer, Models.Answer>();
                cfg.CreateMap<Models.Answer, Common.Answer>();
            });
        }

        public void Create(Common.Answer data)
        {
            Answer newAnswer = Mapper.Map<Answer>(data);
            dbSet.Add(newAnswer);
        }
        public Common.Answer Read(Guid key)
        {
            Answer answer = dbSet.Find(key);
            return Mapper.Map<Common.Answer>(answer);
        }
        public void Update(Common.Answer data)
        {
            Answer updateAnswer = Mapper.Map<Answer>(data);
            updateAnswer = dbSet.Find(data.Id);
            updateAnswer.Name = data.Name;
            updateAnswer.AnswerText = data.AnswerText;

            dbSet.Attach(updateAnswer);
            context.Entry(updateAnswer).State = EntityState.Modified;
        }
        public void Delete(Guid key)
        {
            Answer deleteAnswer = dbSet.Find(key);
            dbSet.Remove(deleteAnswer);
        }
    }
}
