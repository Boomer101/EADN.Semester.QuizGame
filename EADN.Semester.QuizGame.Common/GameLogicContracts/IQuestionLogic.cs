using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.GameLogicContracts
{
    public interface IQuestionLogic
    {
        void CreateQuestion(Question newQuestion);

        Question GetQuestion(Guid id);

        List<Question> GetAllQuestions();

        void UpdateQuestion(Question question);

        void DeleteQuestion(Guid id);
    }
}
