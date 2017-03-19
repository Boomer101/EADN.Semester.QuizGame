using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Common
{
    [ServiceContract(Name="QuizAdmin", Namespace = ConstantValues.XmlNamespace)]
    public interface IQuizAdmin
    {
        [OperationContract(Name ="CreateQuiz")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateQuiz(Quiz newQuiz);

        [OperationContract(Name = "CreateQuizExtended")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateQuiz(Quiz newQuiz, Question newQuestion, List<Answer> newAnswers);

        [OperationContract(Name = "GetQuiz")]
        [FaultContract(typeof(QuizGameFaultException))]
        Quiz GetQuiz(Guid id);

        [OperationContract(Name = "UpdateQuiz")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateQuiz(Quiz quiz);

        [OperationContract(Name = "DeleteQuiz")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteQuiz(Guid id);

      
    }
}