using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.Quiz.Persistence
{
    public class Answer : QuizItem
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public bool ChosenByUser { get; set; }
    }
}
