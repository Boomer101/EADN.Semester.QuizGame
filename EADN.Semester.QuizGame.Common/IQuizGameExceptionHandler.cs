using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    /// <summary>
    /// Interface for handling WCF-Service exceptions
    /// </summary>
    public interface IQuizGameExceptionHandler
    {
        /// <summary>
        /// Creates the exception.
        /// </summary>
        /// <param name="description">A description.</param>
        /// <param name="ex">The exception.</param>
        /// <returns></returns>
        QuizGameFaultException CreateException(string description, Exception ex);
    }
}
