using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Persistence.EF.Interfaces
{
    public interface IQuestionRepository<Question,Guid> : IRepository<Question,Guid>
    {
        IEnumerable<Question> GetAll();
    }
}
