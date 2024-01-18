using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PocConsoleCmdInterceptor.CommandInterceptors
{
    public class TenantFilterCommandInterceptor : DbCommandInterceptor
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
            if (command.CommandText.StartsWith("-- tenantId:", StringComparison.Ordinal))
            {
                // TODO: Refactor this later.... Windows != MacOs
                var tenantId = command.CommandText.Split("\r\n\r\n")[0].Replace("-- tenantId:", string.Empty);

                // Set SESSION_CONTEXT to current UserId before executing queries
                var sql = "EXEC sp_set_session_context @key=N'tenantId', @value=@tenantId;";

                command.CommandText = $"{sql};{command.CommandText}";
                command.Parameters.Insert(0, new SqlParameter("@tenantId", tenantId));
            }
        }
    }
}

