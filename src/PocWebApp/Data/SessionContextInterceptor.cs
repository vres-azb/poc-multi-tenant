using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PocWebApp.Data
{
    public class SessionContextInterceptor : IDbCommandInterceptor
    {
        private void SetSessionContext(DbCommand command)
        {
            try
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                if (userId != null)
                {
                    // Set SESSION_CONTEXT to current UserId before executing queries
                    var sql = "EXEC sp_set_session_context @key=N'UserId', @value=@UserId;";

                    command.CommandText = sql + command.CommandText;
                    command.Parameters.Insert(0, new SqlParameter("@UserId", userId));
                }
            }
            catch (System.NullReferenceException)
            {
                // If no user is logged in, leave SESSION_CONTEXT null (all rows will be filtered)
            }
        }

        //public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        //{
        //    this.SetSessionContext(command);
        //}
        //public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        //{

        //}
        //public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        //{
        //    this.SetSessionContext(command);
        //}
        //public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        //{

        //}
        //public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        //{
        //    this.SetSessionContext(command);
        //}
        //public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        //{

        //}

        public InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
        {
            throw new NotImplementedException();
        }

        public DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            throw new NotImplementedException();
        }

        public InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            throw new NotImplementedException();
        }

        public InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            throw new NotImplementedException();
        }

        public InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            throw new NotImplementedException();
        }

        public ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            throw new NotImplementedException();
        }

        public object? ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object? result)
        {
            throw new NotImplementedException();
        }

        public int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            throw new NotImplementedException();
        }

        public ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<object?> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object? result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            throw new NotImplementedException();
        }

        public Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            throw new NotImplementedException();
        }
    }

    public class SessionContextConfiguration : DbConfiguration
    {
        public SessionContextConfiguration()
        {
            AddInterceptor(new SessionContextInterceptor());
        }
    }
}