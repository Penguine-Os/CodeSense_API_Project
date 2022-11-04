using CodeSense_DAL.Data;

namespace CodeSense_DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    { 
    

        public UnitOfWork(InMemoryDb db)
        {
            TaskRepo = new TaskRepo(db);
            EmployeeRepo = new EmployeeRepo(db);
        }

        public ITaskRepo TaskRepo { get  ; set; }
        public IEmployeeRepo EmployeeRepo { get; set; }

        
    }
}
