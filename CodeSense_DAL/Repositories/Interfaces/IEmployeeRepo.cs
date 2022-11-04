using CodeSense_Models;
using System.Linq.Expressions;


namespace CodeSense_DAL.Repositories
{
    public interface IEmployeeRepo
    {
        IList<Employee> GetAll();
        void Add(Employee Employee);
        void Remove(Employee Employee);
        IList<Employee> GetByFilter(Expression<Func<Employee, bool>> Filters);


    }
}