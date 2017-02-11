using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Persistence
{
    public class Question : QuizItem
    {
        public HashSet<Topic> Topics { get; set; }
        public string Text { get; set; }

        public Question()
        {
            Topics = new HashSet<Topic>();
        }
    }
}
