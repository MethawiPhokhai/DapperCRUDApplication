using DapperCRUDApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDApplication.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAll();
        public Task<Employee> Get(int employeeId);
        public Task<int> AddAsync(Employee employee);
        public Task<int> UpdateAsync(Employee employee);
        public Task<int> DeleteAsync(int employeeId);
    }
}
