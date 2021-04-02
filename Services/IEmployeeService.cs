using DapperCRUDApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDApplication.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAll();
    }
}
