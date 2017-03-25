using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Semester.QuizGame.Common
{
    /// <summary>
    /// Common repository interface
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <typeparam name="K">Key</typeparam>
    public interface IRepository<T,K> 
    {
        /// <summary>
        /// Creates the specified Type.
        /// </summary>
        /// <param name="data">The T data.</param>
        void Create(T data);

        /// <summary>
        /// Gets the Type with the specified key.
        /// </summary>
        /// <param name="key">The K key.</param>
        /// <returns></returns>
        T Read(K key);

        /// <summary>
        /// Updates the specified Type.
        /// </summary>
        /// <param name="data">The T data.</param>
        void Update(T data);

        /// <summary>
        /// Deletes the Type with the specified key.
        /// </summary>
        /// <param name="key">The K key.</param>
        void Delete(K key);

        /// <summary>
        /// Gets all Types
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
    }
}
