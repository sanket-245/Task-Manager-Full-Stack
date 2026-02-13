using Microsoft.AspNetCore.Mvc;
using Services.Services_Interfaces;


namespace TaskManager.API.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskServices _taskservices;

        public TasksController(ITaskServices taskRepository)
        {
            _taskservices = taskRepository;
        }

        /// <summary>
        /// Get the Tasks for the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/tasks")]
        public IActionResult GetTAsks( Guid userid)
        {
            if(userid != null && userid != Guid.Empty)
            {
                var TaskResponse = _taskservices.GetAllAsync();    
               return Ok(TaskResponse);
             
            }
            return BadRequest();
        }
    }
}
