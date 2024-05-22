using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorksTheDaily.API.Repository.Interface;
using WorksTheDaily.API.View;

namespace WorksTheDaily.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _tks;

        public TaskController(ITask tks)
        {
            _tks = tks;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody]TaskPO taskPO)
        {
            var result = await _tks.CreateTask(taskPO);
            return Ok(result);
        }
        [HttpPost("Comment")]
        public async Task<ActionResult> AddComment([FromBody]CommentPO comment)
        {
            var result = await _tks.AddCommet(comment);
            if (!result)
            {
                return BadRequest("Não foi possivél adicionar o comentario a task!");
            }
            return Ok(new
            {
                Resultado = "Comentario Adicionado com Sucesso!",
                comment = comment
            });
        }

        [HttpGet("OpenTask")]
        public async Task<ActionResult> OpenTask(int id)
        {
            var task = await _tks.OpenTask(id);
            return Ok(task);
        }

        [HttpGet("ListTask")]
        public async Task<ActionResult> Listar()
        {
            var taks = await _tks.ListTasks();
            return Ok(taks);
        }
    }
}
