using EADN.Semester.QuizGame.Communication.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Communication.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;

            try
            {
                serviceHost = new ServiceHost(typeof(AdminService));

                Console.WriteLine("Host is running...");
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Caught exception: {exception.Message}");
            }
            finally
            {
                serviceHost?.Close();
            }
        }
    }
}
