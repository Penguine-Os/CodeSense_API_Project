using CodeSense_Models;
using Task = CodeSense_Models.Task;
namespace CodeSense_DAL.Data
{
    public class InMemoryDb
    {

        public IList<Task> Tasks { get; private set; }

        public IList<Employee> Employees { get; private set; }

        public InMemoryDb()
        {
            Tasks = new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Create iOS app",
                    Deadline =  new DateTime(2022,12,24),
                    Requirements = new List<Requirement>()
                    {
                        new Requirement(1,10,new Architect()),
                        new Requirement(2,20,new ProjectManager()),
                        new Requirement(3,30,new Senior()),
                        new Requirement(4, 70, new Junior())

                    }

                }
            };

            Employees = new List<Employee>()
            {
                new Employee("Jos",
                             new Senior(),
                             new DateTime(2022,11,01)),
                new Employee("Francois",
                             new Medior(),
                             new DateTime(2022,11,01))
            };
        }
    }
}