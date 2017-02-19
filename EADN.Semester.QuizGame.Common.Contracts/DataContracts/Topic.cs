using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    [DataContract(Name = "Topic", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    public class Topic : QuizBase
    {
        [DataMember(Order = 0)]
        public string Text { get; set; }
    }
}
