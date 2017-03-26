using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.GameLogicContracts
{
    public interface IQuizLogic
    {
        void CreateQuiz(Quiz newQuiz);

        void CreateQuiz(Quiz newQuiz, Question newQuestion, List<Answer> newAnswers);

        Quiz GetQuiz(Guid id);

        void UpdateQuiz(Quiz quiz);

        void DeleteQuiz(Guid id);
    }
}