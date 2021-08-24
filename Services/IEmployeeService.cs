using System.Collections.Generic;
using System.Threading.Tasks;
using DapperCRUDApplication.Context;

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
