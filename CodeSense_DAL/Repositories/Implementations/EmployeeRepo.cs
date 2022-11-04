using CodeSense_DAL.Data;
using CodeSense_Models;
using System.Linq.Expressions;

namespace CodeSense_DAL.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly InMemoryDb _inMemoryDb;
        public EmployeeRepo(InMemoryDb inMemoryDb)
        {
            _inMemoryDb = inMemoryDb;
        }

        public void Add(Employee Employee)
        {
            _inMemoryDb.Employees.Add(Employee);
        }

        public IList<Employee> GetAll()
        {
            return _inMemoryDb.Employees;
        }

        public IList<Employee> GetByFilter(Expression<Func<Employee, bool>> Filters)
        {

            return _inMemoryDb.Employees.AsQueryable().Where(Filters).ToList();
        }

        public void Remove(Employee Employee)
        {
            _inMemoryDb.Employees.Remove(Employee);
        }
    }
}