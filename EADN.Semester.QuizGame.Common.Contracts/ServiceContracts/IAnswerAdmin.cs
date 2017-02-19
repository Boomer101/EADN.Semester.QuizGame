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
    [ServiceContract(Name = "AnswerAdmin", Namespace = ConstantValues.XmlNamespace)]
    public interface IAnswerAdmin
    {
        [OperationContract(Name = "CreateAnswer")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateAnswer(Answer newAnswer);

        [OperationContract(Name = "GetAnswer")]
        [FaultContract(typeof(QuizGameFaultException))]
        Answer GetAnswer(Guid id);

        [OperationContract(Name = "UpdateAnswer")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateAnswer(Answer answer);

        [OperationContract(Name = "DeleteAnswer")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteAnswer(Guid id);
    }
}
