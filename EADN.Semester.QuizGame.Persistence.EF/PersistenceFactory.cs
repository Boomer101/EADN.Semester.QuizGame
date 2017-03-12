using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Persistence.EF
{
    public class PersistenceFactory : IPersistence
    {
        public IData GetDataAccesLayer()
        {
            return new UnitOfWork();
        }
    }
}
