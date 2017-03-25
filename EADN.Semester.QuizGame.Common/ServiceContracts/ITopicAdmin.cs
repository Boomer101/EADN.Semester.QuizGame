using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EADN.Semester.QuizGame.Common
{
    [ServiceContract(Name = "TopicAdminService", Namespace = ConstantValues.XmlNamespace)]
    public interface ITopicAdmin
    {
        [OperationContract(Name = "CreateTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateTopic(Topic topic);

        [OperationContract(Name = "GetTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        Topic GetTopic(Guid id);

        [OperationContract(Name = "GetAllTopics")]
        [FaultContract(typeof(QuizGameFaultException))]
        List<Topic> GetAllTopics();

        [OperationContract(Name = "UpdateTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateTopic(Topic topic);

        [OperationContract(Name = "DeleteTopic")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteTopic(Guid id);
    }
}
