using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.Quiz.Common
{
    public interface IRepository<T,K>
    {
        void Create(T data);
        T ReadById(K Key);
        void Update(T data);
        void Delete(K key);
    }
}
