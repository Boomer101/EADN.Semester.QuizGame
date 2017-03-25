using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    /// <summary>
    /// Persistence Interface
    /// To be instantiated by a persistence layer
    /// </summary>
    public interface IPersistence
    {
        IData GetDataAccessLayer(); 
    }
}
