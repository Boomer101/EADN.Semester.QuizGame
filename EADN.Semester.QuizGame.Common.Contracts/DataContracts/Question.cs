using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    [DataContract(Name = "Question", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    public class Question : QuizItem
    {
        [DataMember(Order = 0)]
        public HashSet<Topic> Topics { get; set; }

        [DataMember(Order = 0)]
        public string Text { get; set; }

    }
}
