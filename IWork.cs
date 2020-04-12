using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork
{
    public interface IWork:IDisposable
    {
        /// <summary>
        /// Commit Current Transaction
        /// </summary>
        void Commit();
        /// <summary>
        /// Rollback Current Transaction
        /// </summary>
        void Rollback();
        new void Dispose();
    }
}
