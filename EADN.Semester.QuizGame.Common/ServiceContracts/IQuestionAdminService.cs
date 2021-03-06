﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Common
{
    [ServiceContract(Name = "QuestionAdminService", Namespace = ConstantValues.XmlNamespace)]
    public interface IQuestionAdminService
    {
        [OperationContract(Name = "CreateQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void CreateQuestion(Question newQuestion);

        [OperationContract(Name = "GetQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        Question GetQuestion(Guid id);

        [OperationContract(Name = "GetAllQuestions")]
        [FaultContract(typeof(QuizGameFaultException))]
        List<Question> GetAllQuestions();

        [OperationContract(Name = "UpdateQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void UpdateQuestion(Question question);

        [OperationContract(Name = "DeleteQuestion")]
        [FaultContract(typeof(QuizGameFaultException))]
        void DeleteQuestion(Guid id);
    }
}
