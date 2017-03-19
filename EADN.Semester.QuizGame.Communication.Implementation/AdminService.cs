using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;
using System.ServiceModel;

namespace EADN.Semester.QuizGame.Communication.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class AdminService : IQuizAdmin, IQuestionAdmin, IAnswerAdmin, ITopicAdmin
    {
        private IPersistence persistenceFactory;

        private IData DAL;

        private IRepository<Common.Quiz,Guid> quizRepository;

        public AdminService()
        {
            persistenceFactory = AssemblyFactory.LoadInstance<IPersistence>(Environment.CurrentDirectory, "EADN.Semester.QuizGame.Persistence.EF.dll");
        }

        public void CreateAnswer(Answer newAnswer)
        {
            throw new NotImplementedException();    
        }

        public void CreateQuestion(Question newQuestion)
        {
            throw new NotImplementedException();
        }

        public void CreateQuiz(Quiz newQuiz)
        {
            try
            {
                using (DAL = persistenceFactory.GetDataAccessLayer())
                {
                    quizRepository = DAL.GetQuizRepository();
                    quizRepository.Create(newQuiz);
                    DAL.Save();
                }
            }
            catch (Exception ex)
            {
                QuizGameFaultException objFault = new QuizGameFaultException
                    { Title = newQuiz.ToString(), Message = ex.Message, InnerExceptionMessage = ex.InnerException.Message };
                throw new FaultException<QuizGameFaultException>(objFault);
            }
        }

        public void CreateQuiz(Quiz newQuiz, Question newQuestion, List<Answer> newAnswers)
        {
            //newQuiz.Question = newQuestion;
            //newQuiz.Question.Answers = newAnswers;

            using (DAL = persistenceFactory.GetDataAccessLayer())
            {
                quizRepository = DAL.GetQuizRepository();
                quizRepository.Create(newQuiz);
                DAL.Save();
            }
        }

        public void CreateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnswer(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid id)
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

        public Answer GetAnswer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(Guid id)
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

        public void UpdateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(Question question)
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
