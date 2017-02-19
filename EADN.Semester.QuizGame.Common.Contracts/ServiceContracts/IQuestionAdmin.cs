using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Common.Contracts;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    [ServiceContract(Name = "QuestionAdmin", Namespace = ConstantValues.XmlNamespace)]
    public interface IQuestionAdmin
    {
        [OperationContract(Name = "CreateQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateQuestion(Question newQuestion);

        [OperationContract(Name = "GetQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        Question GetQuestion(Guid id);

        [OperationContract(Name = "UpdateQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateQuestion(Question question);

        [OperationContract(Name = "DeleteQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteQuestion(Guid id);
    }
}
