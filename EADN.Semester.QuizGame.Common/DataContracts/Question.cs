using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    [DataContract(Name = "Question", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    public class Question : QuizBase
    {
        [DataMember(Name="Text", Order = 0)]
        public string Text { get; set; }

        [DataMember(Name="Topics", Order = 0)]
        public List<Topic> Topics { get; set; }

        [DataMember(Name= "Quizzes", Order = 0)]
        public List<Quiz> Quizzes { get; set; }

        [DataMember(Name="Answers", Order = 0)]
        public List<Answer> Answers { get; set; }
    }
}
