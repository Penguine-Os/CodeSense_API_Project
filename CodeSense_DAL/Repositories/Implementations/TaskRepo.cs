
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CodeSense_DAL.Data;
using Task = CodeSense_Models.Task;

namespace CodeSense_DAL.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly InMemoryDb _inMemoryDb;
        public TaskRepo(InMemoryDb inMemoryDb)
        {
            _inMemoryDb = inMemoryDb;
        }

        public void Add(Task Task)
        {
             _inMemoryDb.Tasks.Add(Task);
        }

        public IList<Task> GetAll()
        {
            return _inMemoryDb.Tasks;
        }

        public Task GetByFilter(Expression<Func<Task, bool>> Filters)
        {
            IQueryable<Task> query = _inMemoryDb.Tasks.AsQueryable();
            return query.FirstOrDefault(Filters);
        }

        public void Remove(Task Task)
        {
            _inMemoryDb.Tasks.Remove(Task);
        }
    }
}
