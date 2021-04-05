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
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbConnection.GetAllAsync<Employee>();
        }

        public async Task<Employee> Get(int employeeId)
        {
            const string getQuery = "SELECT * FROM Employees WHERE EmployeeId = @employeeId";
            return await _dbConnection.QuerySingleAsync<Employee>(getQuery, new { employeeId = employeeId });
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var sql = "Insert into Employees (Name,Address,CompanyName,Designation) VALUES (@Name,@Address,@CompanyName,@Designation)";
            var result = await _dbConnection.ExecuteAsync(sql, employee);
            return result;
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            var sql = "UPDATE Employees SET Name = @Name, Address = @Address, CompanyName = @CompanyName, Designation = @Designation WHERE EmployeeId = @EmployeeId";
            var result = await _dbConnection.ExecuteAsync(sql, employee);
            return result;
        }

        public async Task<int> DeleteAsync(int employeeId)
        {
            var sql = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
            var result = await _dbConnection.ExecuteAsync(sql, new { EmployeeId = employeeId });
            return result;
        }
    }
}
