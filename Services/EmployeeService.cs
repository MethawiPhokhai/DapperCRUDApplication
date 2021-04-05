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
        private readonly IDbConnection _dbConnection;

        public EmployeeService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _dbConnection.GetAllAsync<Employee>().Result;
        }

        public async Task<Employee> Get(int id)
        {
            using (IDbConnection db = _dbConnection)
            {
                const string getQuery = "SELECT * FROM Employees WHERE EmployeeId = @employeeId";
                return await db.QuerySingleAsync<Employee>(getQuery, new { id });
            }
        }
    }
}
