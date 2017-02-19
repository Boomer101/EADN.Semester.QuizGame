using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EADN.Semester.QuizGame.Common;
using EADN.Semester.QuizGame.Common.Contracts;

namespace EADN.Semester.QuizGame.Communication.Contracts
{
    [ServiceContract(Name = "TopicAdmin", Namespace = ConstantValues.XmlNamespace)]
    interface ITopicAdmin
    {
        [OperationContract(Name = "CreateTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateTopic(Topic topic);

        [OperationContract(Name = "GetTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        Topic GetTopic(Guid id);

        [OperationContract(Name = "UpdateTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateTopic(Topic topic);

        [OperationContract(Name = "DeleteTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteTopic(Guid id);
    }
}
