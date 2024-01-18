//using System;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using System.Data.Common;

//namespace PocConsoleCmdInterceptor.CommandInterceptors
//{
//	public abstract class BaseDbCommandInterceptor: DbCommandInterceptor
//    {
//        public override InterceptionResult<DbDataReader> ReaderExecuting(
//            DbCommand command,
//            CommandEventData eventData,
//            InterceptionResult<DbDataReader> result)
//        {
//            InterceptCommand(command);

//            return result;
//        }

//        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
//            DbCommand command,
//            CommandEventData eventData,
//            InterceptionResult<DbDataReader> result,
//            CancellationToken cancellationToken = default)
//        {
//            InterceptCommand(command);

//            return new ValueTask<InterceptionResult<DbDataReader>>(result);
//        }

//        protected internal override void InterceptCommand(DbCommand command)
//        {

//        }
//    }
//}

