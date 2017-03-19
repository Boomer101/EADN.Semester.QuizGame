using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Common
{
    [DataContract(Name = "Answer", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    public class Answer : QuizBase
    {
        [DataMember(Name="AnswerText", Order = 0)]
        public string AnswerText { get; set; }

        [DataMember(Order = 0)]
        public bool IsCorrect { get; set; }

        [DataMember(Order = 0)]
        public bool ChosenByUser { get; set; }
    }
}
