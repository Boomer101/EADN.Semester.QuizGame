using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    internal interface IConfigHandler
    {
        void GetAssemblyConfigReferences<T>(out string filePath, out string dllFileName);
    }
}
