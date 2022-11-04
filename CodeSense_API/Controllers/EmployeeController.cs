using CodeSense_DAL.Repositories;
using CodeSense_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public EmployeeController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IList<Employee> Emp = _db.EmployeeRepo.GetAll();

            if (Emp is null)
                return NotFound();

            return new JsonResult(Emp);
        }

    }
}
