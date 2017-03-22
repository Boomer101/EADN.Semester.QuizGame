using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    [DataContract(Name = "Quiz", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    public class Quiz : QuizBase
    {
        [DataMember(Name="QuizType", Order = 0)]
        public QuizType QuizType { get; set; }

        [DataMember(Name="Questions", Order = 0)]
        public List<Question> Questions { get; set; }

        [DataMember(Name= "MinAmountQuestions", Order = 0)]
        public int MinAmountQuestions { get; set; }

        [DataMember(Name = "MaxAmountQuestions", Order = 0)]
        public int MaxAmountQuestions { get; set; }
    }
}

