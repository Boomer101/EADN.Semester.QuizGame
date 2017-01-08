using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizData
{
    public class Quiz : QuizGameElement
    {
        public HashSet<Topic> Topics { get; set; }
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

