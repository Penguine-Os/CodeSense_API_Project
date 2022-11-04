using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense_DAL.Repositories
{
    public interface IUnitOfWork
    {
        public ITaskRepo  TaskRepo { get; set; }
        public IEmployeeRepo  EmployeeRepo { get; set; }


    }
}
