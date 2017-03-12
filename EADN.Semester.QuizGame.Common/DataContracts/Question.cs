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
        [DataMember(Order = 0)]
        public List<Topic> Topics { get; set; }

        [DataMember(Order = 0)]
        public string Text { get; set; }
    }
}
