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
        /// <summary>
        /// Loads the instance for the desired Type T.
        /// Location of the desired assembly.dll from config
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LoadInstance<T>() where T : class
        {
            string filePath;
            string dllFileName;

            // Get config values
            IAssemblyConfigHandler config = new AssemblyConfigHandler();
            config.GetAssemblyConfigReferences<T>(out filePath, out dllFileName);

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
                           where t.GetInterfaces().Contains(typeof(T)) || t == typeof(T)
                           select Activator.CreateInstance(t) as T;

            return instance.FirstOrDefault();
        }

        /// <summary>
        /// Loads the instance for the desired Type T.
        /// Location of the desired assembly.dll as params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <param name="dllFileName">Name of the DLL file.</param>
        /// <returns></returns>
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
                           where t.GetInterfaces().Contains(typeof(T)) || t == typeof(T)
                           select Activator.CreateInstance(t) as T;

            return instance.FirstOrDefault();     
        }
    }
}
