using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common.Contracts
{
    [DataContract]
    public class QuizGameFaultException
    {
        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string InnerExceptionMessage { get; set; }

        [DataMember]
        public string StackTrace { get; set; }
    }
}