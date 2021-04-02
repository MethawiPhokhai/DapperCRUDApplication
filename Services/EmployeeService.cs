using Dapper.Contrib.Extensions;
using DapperCRUDApplication.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
    }
}
