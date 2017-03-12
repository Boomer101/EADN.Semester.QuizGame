using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    public interface IData : IDisposable
    {
        IRepository<Question, Guid> GetQuestionRepository();
        IRepository<Quiz, Guid> GetQuizRepository();
        IRepository<Topic, Guid> GetTopicRepository();
        void Save();
    }
}
