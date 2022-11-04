using CodeSense_DAL.Repositories;
using CodeSense_Models;
using Task = CodeSense_Models.Task;

namespace CodeSense_DAL
{
    public static class ResourcePlanner
    {
        public static IEnumerable<Employee> ReturnsSuitableEmployeesForGivenTask(IUnitOfWork unitOfWork, Task task)
        {
            IList<Employee> SuitbleEmployees = unitOfWork.EmployeeRepo.GetByFilter(emp => emp.AvailableFrom > task.Deadline);

            //  Indien geen beschikbare werknemers, wordt er een lege enumerable gestuurd
            if (SuitbleEmployees is null)
                return Enumerable.Empty<Employee>();

            //
            //  Hieronder wordt deze lijst nog verder verfijd
            //  Soorten filters:
            //      -   bevaten deze werknemers de nodige Level
            //      -   Matchet hun expertise aan de workload => af te leiden a.d.h.v "Amount" hours
            //      -   Is dit het goedkoopste optie
            //
            //

            return unitOfWork.EmployeeRepo.GetAll();
        }
    }
}
