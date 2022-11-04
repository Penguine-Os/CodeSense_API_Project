using System.Linq.Expressions;
using Task = CodeSense_Models.Task;
namespace CodeSense_DAL.Repositories
{
    public interface ITaskRepo
    {
        IList<Task> GetAll();
        void Add(Task Task);
        void Remove(Task Task);
        Task GetByFilter(Expression<Func<Task, bool>> Filters);

    }
}