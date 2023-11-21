using _17112023webapicrud.Models;
using Microsoft.EntityFrameworkCore;

namespace _17112023webapicrud.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return 0;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
