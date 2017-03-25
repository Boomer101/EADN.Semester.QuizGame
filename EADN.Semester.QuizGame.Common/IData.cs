using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    /// <summary>
    /// Data interface. Defines the Common Repository-Interfaces needed.
    /// To be implemented as a Unit-of-Work in persistence layer.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IData : IDisposable
    {
        IRepository<Answer, Guid> GetAnswerRepository();
        IRepository<Question, Guid> GetQuestionRepository();
        IRepository<Quiz, Guid> GetQuizRepository();
        IRepository<Topic, Guid> GetTopicRepository();
        void Save();
    }
}
