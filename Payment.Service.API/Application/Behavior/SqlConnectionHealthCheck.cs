// using Microsoft.Extensions.Diagnostics.HealthChecks;

// namespace Plooto.Assessment.Payment.API.Application;

// public class SqlConnectionHealthCheck : IHealthCheck
// {
//     private const string DefaultTestQuery = "SELECT * FROM sys.databases";

//     public string ConnectionString { get; }

//     public string TestQuery { get; }

//     public SqlConnectionHealthCheck(string connectionString)
//         : this(connectionString, testQuery: DefaultTestQuery)
//     {
//     }

//     public SqlConnectionHealthCheck(string connectionString, string testQuery)
//     {
//         ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
//         TestQuery = testQuery;
//     }

//     public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
//     {
//         using (var connection = new SqlConnection(ConnectionString))
//         {
//             try
//             {
//                 await connection.OpenAsync(cancellationToken);

//                 if (TestQuery != null)
//                 {
//                     var command = connection.CreateCommand();
//                     command.CommandText = TestQuery;

//                     await command.ExecuteNonQueryAsync(cancellationToken);
//                 }
//             }
//             catch (DbException ex)
//             {
//                 return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
//             }
//         }

//         return HealthCheckResult.Healthy();
//     }
// }