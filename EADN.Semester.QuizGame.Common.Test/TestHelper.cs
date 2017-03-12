using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EADN.Semester.QuizGame.Common.Test
{
    public static class TestHelper
    {
        public static T DataContractMemoryTest<T>(T obj, IEnumerable<Type> knownTypes)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType(), knownTypes);
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;

            obj = (T)serializer.ReadObject(stream);

            return obj;
        }
    }
}
