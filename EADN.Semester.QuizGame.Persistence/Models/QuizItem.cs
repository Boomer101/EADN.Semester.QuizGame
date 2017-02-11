using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence
{
    public abstract class QuizItem : IQuizItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
