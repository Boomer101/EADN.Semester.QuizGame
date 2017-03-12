using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    public static class AssemblyFactory
    {
        public static T LoadInstance<T>(string filePath, string dllFileName) where T : class
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom(Path.Combine(filePath, dllFileName));
                if (assembly != null)
                {
                    Console.WriteLine($"Assembly {assembly} successfully loaded");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Assembly {dllFileName} could not be loaded ! Exception {ex.Message}");
                return default(T);
            }

            var instance = from t in assembly.GetTypes()
                           where t.GetInterfaces().Contains(typeof(T))
                           || t == typeof(T)
                           select Activator.CreateInstance(t) as T;

            return instance.FirstOrDefault();     
        }
    }
}
