using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizData
{
    public abstract class QuizItem : IQuizItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public QuizGameElement QuizGame { get; set; }
    }
}
