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
        [DataMember(Order = 0)]
        public QuizType QuizType { get; set; }

        //[DataMember(Order = 0)]
        //public HashSet<Topic> Topics { get; set; }

        [DataMember(Order = 0)]
        public Question Question { get; set; }

        [DataMember(Order = 0)]
        public List<Answer> Answers { get; set; }
    }
}

