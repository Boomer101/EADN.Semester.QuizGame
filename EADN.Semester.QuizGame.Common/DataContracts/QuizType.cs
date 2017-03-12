using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EADN.Semester.QuizGame.Common
{
    [DataContract(Name ="QuizType", Namespace =ConstantValues.XmlNamespace)]
    public enum QuizType
    {
        [EnumMember]
        YesOrNo,

        [EnumMember]
        MultipleChoice
    };
}
