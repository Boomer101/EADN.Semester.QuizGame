using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.Quiz.Persistence
{
    public abstract class QuizItem : IQuizItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
