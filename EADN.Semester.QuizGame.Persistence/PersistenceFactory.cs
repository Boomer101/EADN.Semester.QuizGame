using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Persistence
{
    public class PersistenceFactory : IPersistence
    {
        static PersistenceFactory()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Common.Topic, Topic>();
            });
        }
        public IRepository<Common.Topic, Guid> GetTopicRepository()
        {
            return AssemblyFactory.LoadAssembly<>
        }
    }
}
