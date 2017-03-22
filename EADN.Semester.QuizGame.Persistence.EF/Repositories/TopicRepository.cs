using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence = EADN.Semester.QuizGame.Persistence;
using EADN.Semester.QuizGame.Common;
using System.Data.Entity;
using EADN.Semester.QuizGame.Persistence.EF.Interfaces;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class TopicRepository : ITopicRepository<Common.Topic, Guid>
    {
        internal QuizGameContext context;
        internal DbSet<Models.Topic> dbSet;
        public TopicRepository(QuizGameContext context)
        {
            this.context = context;
            dbSet = context.Set<Models.Topic>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Topic, Models.Topic>();
                cfg.CreateMap<Models.Topic, Common.Topic>();
                cfg.CreateMap<Common.Question, Models.Question>();
                cfg.CreateMap<Models.Question, Common.Question>();
            });
        }
        public void Create(Common.Topic data)
        {
            Models.Topic newTopic = Mapper.Map<Models.Topic>(data);
            dbSet.Add(newTopic);
        }
        public Common.Topic Read(Guid key)
        {
            Models.Topic readTopic = dbSet.Find(key);
            return Mapper.Map<Common.Topic>(readTopic);
        }
        public void Delete(Guid key)
        {
            Models.Topic deleteTopic = context.Topics.Find(key);
            // TODO State detached beachten ?
            dbSet.Remove(deleteTopic);
        }

        public void Update(Common.Topic data)
        {
            Models.Topic updateTopic = Mapper.Map<Models.Topic>(data);
            updateTopic = dbSet.Find(data.Id);
            updateTopic.Name = data.Name;
            updateTopic.Text = data.Text;

            dbSet.Attach(updateTopic);
            context.Entry(updateTopic).State = EntityState.Modified;
        }

        public IEnumerable<Common.Topic> GetAllTopics()
        {
            List<Models.Topic> allTopics = dbSet.ToList();
            return Mapper.Map<List<Models.Topic>, IEnumerable<Common.Topic>>(allTopics);
        }
    }
}
