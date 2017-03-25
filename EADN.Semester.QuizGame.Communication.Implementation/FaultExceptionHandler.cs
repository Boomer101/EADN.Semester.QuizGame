using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Semester.QuizGame.Common;

namespace EADN.Semester.QuizGame.Communication.Implementation
{
    public class FaultExceptionHandler : IQuizGameExceptionHandler
    {
        QuizGameFaultException objFault;
        public QuizGameFaultException CreateException(string desc, Exception ex)
        {
            objFault = new QuizGameFaultException
            { Title = desc ?? string.Empty, Message = ex.Message, InnerExceptionMessage = ex.InnerException.Message };

            return objFault;
        }
    }
}
