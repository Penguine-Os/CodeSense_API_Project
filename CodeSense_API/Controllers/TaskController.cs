using CodeSense_DAL;
using CodeSense_DAL.Repositories;
using CodeSense_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Task = CodeSense_Models.Task;

namespace CodeSense_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/TaskController
        [HttpGet]
        public IActionResult Get()
        {
            IList<Task> Tasks = _unitOfWork.TaskRepo.GetAll();

            if (Tasks is null)
                return NotFound();

            return new JsonResult(Tasks);
        }

        // GET api/TaskController/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Task task = _unitOfWork.TaskRepo.GetByFilter(x => x.Id == id);

            if (task is null)
                return NotFound();

            return new JsonResult(task);
        }

        //POST api/TaskController
        [HttpPost]
        public IActionResult Post([FromForm] Task task)
        {
            if (!task.IsValid())
                return BadRequest();

            //
            //  als Task geen errors bevat wordt het verder verwerkt in ResourcePlanner
            //  Hier wordt naar mogelijke matchs gezocht.
            //  als deze static methode Lege lijst mee geeft wordt deze taak niet geregistreerd in de DB
            //   

            IList<Employee> SuitableEmps = ResourcePlanner.ReturnsSuitableEmployeesForGivenTask(_unitOfWork, task).ToList();

            if (SuitableEmps.Count > 0)
            {
                //  Task wordt geregistreerd
                _unitOfWork.TaskRepo.Add(task);
                //  en als response wordt er een lijst van employees gestuurd
                return new JsonResult(SuitableEmps);
            }

            return Ok();
        }
    }
}
