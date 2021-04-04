using Dapper;
using Dapper.Contrib.Extensions;
using DapperCRUDApplication.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperCRUDApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private SqlConnection _sqlConnection;
        public IConfiguration Configuration { get; }

        public EmployeeService(IConfiguration Configuration)
        {
            _sqlConnection = new SqlConnection(Configuration.GetConnectionString("DapperConn"));
        }
        public IEnumerable<Employee> GetAll()
        {
            return _sqlConnection.GetAllAsync<Employee>().Result;
        }

        public async Task<Employee> Get(int id)
        {
            using (IDbConnection db = _sqlConnection)
            {
                const string getQuery = "SELECT * FROM Employees WHERE EmployeeId = @employeeId";
                return await db.QuerySingleAsync<Employee>(getQuery, new { id });

            }
        }
    }
}
