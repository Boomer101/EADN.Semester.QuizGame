using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    public interface IPersistence
    {
        IData GetDataAccessLayer(); 
    }
}
