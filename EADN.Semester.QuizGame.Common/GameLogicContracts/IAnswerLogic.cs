using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.GameLogicContracts
{
    public interface IAnswerLogic
    {
        void CreateAnswer(Answer newAnswer);
        Answer GetAnswer(Guid id);

        List<Answer> GetAllAnswers();
    
        void UpdateAnswer(Answer answer);

        void DeleteAnswer(Guid id);
    }
}
