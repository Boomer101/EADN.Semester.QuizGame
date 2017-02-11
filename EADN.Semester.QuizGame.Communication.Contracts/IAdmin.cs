using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EADN.Semester.QuizGame.Common.Contracts;

namespace EADN.Semester.QuizGame.Communication.Contracts
{
    [ServiceContract(Name="QuizAdmin", Namespace =ConstantValues.XmlNamespace)]
    public interface IQuizAdmin
    {
        [OperationContract(Name ="CreateQuiz")]
        void CreateQuiz(Quiz newQuiz);

        [OperationContract(Name = "CreateQuizExtended")]
        void CreateQuiz(Quiz newQuiz, Question newQuestion, Answer newAnswer, Topic newTopic);

        [OperationContract(Name = "GetQuiz")]
        Quiz GetQuiz(Guid id);

        [OperationContract(Name = "UpdateQuiz")]
        void UpdateQuiz(Quiz quiz);

        [OperationContract(Name = "DeleteQuiz")]
        void DeleteQuiz(Guid id);

        [OperationContract(Name = "CreateTopic")]
        void CreateTopic(Topic topic);

        [OperationContract(Name = "GetTopic")]
        Topic GetTopic(Guid id);

        [OperationContract(Name = "UpdateTopic")]
        void UpdateTopic(Topic topic);

        [OperationContract(Name = "DeleteTopic")]
        void DeleteTopic(Guid id);
    }
}