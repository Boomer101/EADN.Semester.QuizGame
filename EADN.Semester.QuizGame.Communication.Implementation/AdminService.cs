using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Communication.Contracts;
using EADN.Semester.QuizGame.Common.Contracts;

namespace EADN.Semester.QuizGame.Communication.Implementation
{
    public class AdminService : IQuizAdmin
    {
        public void CreateQuiz(Quiz newQuiz)
        {
            throw new NotImplementedException();
        }

        public void CreateQuiz(Quiz newQuiz, Question newQuestion, Answer newAnswer, Topic newTopic)
        {
            throw new NotImplementedException();
        }

        public void CreateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuiz(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTopic(Guid id)
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuiz(Guid id)
        {
            throw new NotImplementedException();
        }

        public Topic GetTopic(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public void UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
