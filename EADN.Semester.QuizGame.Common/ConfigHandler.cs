using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    internal class ConfigHandler : IConfigHandler
    {
        public void GetAssemblyConfigReferences<T>(out string filePath, out string dllFileName)
        {
            CustomAssemblySection configSection = (CustomAssemblySection)ConfigurationManager.GetSection("customAssemblySection");
            CustomAssemblyConfigElement configElementAssembly = new CustomAssemblyConfigElement();
            foreach (CustomAssemblyConfigElement item in configSection.ConfigElementCollection)
            {
                if (item.Key.Equals(typeof(T).Name))
                {
                    configElementAssembly = item;
                }
            }

            filePath = configElementAssembly.Dir;
            dllFileName = configElementAssembly.Dll;
        }
    }
}
