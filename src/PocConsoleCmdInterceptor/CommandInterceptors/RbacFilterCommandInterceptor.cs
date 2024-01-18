using System;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PocConsoleCmdInterceptor.CommandInterceptors
{
	public class RbacFilterCommandInterceptor: DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            InterceptCommand(command);

            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            InterceptCommand(command);

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private static void InterceptCommand(DbCommand command)
        {
            
            var tenantId = 1;
            var roleId = "Admin";
            var userId = 1;

            // Set SESSION_CONTEXT to current UserId before executing queries
            var setSqlContext =
                string.Concat(
                "EXEC sp_set_session_context @key=N'tenantId', @value=@tenantId;",
                //"EXEC sp_set_session_context @key=N'roleId', @value=@roleId;",
                "EXEC sp_set_session_context @key=N'userId', @value=@userId;",
                $";{command.CommandText}");

            command.CommandText = $"{setSqlContext};{command.CommandText}";
            //command.Parameters.Insert(0, new SqlParameter("@tenantId", tenantId));
            command.Parameters.AddRange(new[]{
                new SqlParameter("@tenantId", tenantId),
                //new SqlParameter("@roleId", roleId),
                new SqlParameter("@userId", userId)
            });
            //command.Parameters.Insert(1, new SqlParameter("@roleId", roleId));

        }
    }
}

