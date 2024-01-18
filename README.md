# POC Multi-tenant w/ EF :ugh:

1. Add an Interceptor class in the application to set the `SESSION_CONTEX()T`
1. Create a Row-Level Security policy in the database

## Resources

### EF
- [Tutorial: Web app with a multi-tenant database using Entity Framework and Row-Level Security](https://github.com/Huachao/azure-content/blob/master/articles/app-service-web/web-sites-dotnet-entity-framework-row-level-security.md)
- [Logging and intercepting database operations](https://learn.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception?redirectedfrom=MSDN)
- [Table schema](https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=data-annotations)

#### Least relevant

- [Multi-tenant applications with elastic database tools and row-level security](https://github.com/Huachao/azure-content/blob/master/articles/sql-database/sql-database-elastic-tools-multi-tenant-row-level-security.md)

### SQL

#### Least relevant

- [SQL Server SESSION_CONTEXT() function with examples](https://www.sqlshack.com/sql-server-session_context-function-with-examples/)
- [CREATE SECURITY POLICY - B. Create a policy that affects multiple tables](https://learn.microsoft.com/en-us/sql/t-sql/statements/create-security-policy-transact-sql?view=sql-server-ver16&source=recommendations)

