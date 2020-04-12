using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UnitOfWork
{
    /// <summary>
    /// <see cref="IUnitOfWork"/>
    /// </summary>
    public class SqlUnitOfWork : IUnitOfWork
    {
        private  IDbTransaction transaction;
        private  IDbConnection connection;
        private readonly DbContext dbContext;
        public SqlUnitOfWork(IOptions<DbContext> options)
        {
            this.dbContext = options.Value?? throw new ArgumentNullException(nameof(options));
        }
        /// <summary>
        /// <see cref="IUnitOfWork.Transaction"/>
        /// </summary>
        public IDbTransaction Transaction
        {
            get { return transaction; }
        }
        /// <summary>
        /// <see cref="IUnitOfWork.Connection"/>
        /// </summary>
        public IDbConnection Connection
        {
            get { return connection; }
        }
        /// <summary>
        /// <see cref="IUnitOfWork.Begin"/>
        /// </summary>
        /// <returns></returns>
        public IWork Begin()
        {
            connection = new SqlConnection(dbContext.DbConnection);
            connection.Open();
            transaction = connection.BeginTransaction();
            return new Sqlwork(transaction, connection);
        }
    }
}
