using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UnitOfWork
{
   public interface IUnitOfWork
    {
         IDbTransaction Transaction{ get; }
         IDbConnection Connection { get;}
        IWork Begin();
    }
}
