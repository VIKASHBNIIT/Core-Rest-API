using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UnitOfWork
{
    ///<see cref="IWork"/>
    public class Sqlwork : IWork
    {
        private readonly IDbTransaction transaction;
        private readonly IDbConnection connection;
        public Sqlwork(IDbTransaction transaction , IDbConnection connection)
        {
            this.transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        ///<see cref="IWork.Commit"/>
        public void Commit()
        {
            transaction.Commit();
            connection.Close();
        }
        /// <see cref="IWork.Dispose"/>
        public void Dispose()
        {
            connection.Dispose();
        }
        /// <see cref="IWork.Rollback"/>
        public void Rollback()
        {
            transaction.Rollback();
            connection.Close();
        }
    }
}
