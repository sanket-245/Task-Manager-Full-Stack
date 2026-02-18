using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Services_Interfaces;


namespace TaskManager.API.Controllers
{
    [Authorize]
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
        public async Task< IActionResult> GetTasks(Guid userid)
        {
            if(userid != null && userid != Guid.Empty)
            {
                var TaskResponse =  await _taskservices.GetAllAsync();    
               return Ok(TaskResponse);
             
            }
            return BadRequest();
        }

        /// <summary>
        /// Get the Tasks by Id for the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/task-by-id")]
        public async Task<IActionResult> GetTask(Guid userid, Guid taskid)
        {
            if (userid != null && userid != Guid.Empty && taskid != null && taskid != Guid.Empty)
            {
                var TaskResponse = await _taskservices.GetByIdAsync(taskid);
                return Ok(TaskResponse);

            }
            return BadRequest();
        }

        /// <summary>
        /// Get the Tasks by Id for the user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/create-task")]
        public async Task<IActionResult> AddTask([FromBody]CreateTaskDTO taskdto)
        {
            if (taskdto != null)
            {
                await _taskservices.CreateAsync(taskdto);
                return Ok();

            }
            return BadRequest();
        }

        /// <summary>
        /// Get the Tasks by Id for the user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskStatusDTO updatetaskdto, Guid taskid)
        {
            if (updatetaskdto != null && taskid != null)
            {
                await _taskservices.UpdateStatusAsync(taskid,updatetaskdto);
                return Ok();

            }
            return BadRequest();
        }

        /// <summary>
        /// Get the Tasks by Id for the user
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("/delete-task")]
        public async Task<IActionResult>  DeleteTask(Guid taskid)
        {
            if ( taskid != null && taskid != Guid.Empty)
            {
                await _taskservices.DeleteAsync(taskid);
                return Ok();

            }
            return BadRequest();
        }

    }
}
