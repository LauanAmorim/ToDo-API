using Microsoft.AspNetCore.Mvc;
using Trendx_toDo.Repositories;
using Trendx_toDo.ViewModels;

namespace Trendx_toDo.Controllers
{

    [ApiController]
    [Route("api")]
    public class TodoController : Controller
    {

        private readonly ITaskRepository _TaskRepository;

        public TodoController(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        /// <summary>
        /// Criar uma nova tarefa.
        /// </summary>
        /// <param name="model">Detalhes da tarefa.</param>
        /// <returns>Retorna a nova tarefa criada.</returns>

        [HttpPost("tasks")]
        public async Task<IActionResult> Post([FromBody] CreateTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var task = await _TaskRepository.AddTaskAsync(model);
                return Created($"api/tasks/{task.Id}", task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }


        /// <summary>
        /// Obter a lista de todas as tarefas.
        /// </summary>
        /// <returns>Retorna uma lista de todas as tarefas</returns>
        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> Get()
        {
            var tasks = await _TaskRepository.GetTasksAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Atualizar uma tarefa.
        /// </summary>
        /// <param name="model">Informações a serem atuailizadas</param>
        /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <returns>Retorna Ok se a tarefa for atualizada; Se não, retorna NotFound.</returns>
        [HttpPut("tasks/{id}")]
        public async Task<IActionResult> Put([FromBody] EditTaskViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var success = await _TaskRepository.UpdateTaskAsync(id, model);
                return success ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Deletar uma tarefa.
        /// </summary>
        /// <param name="id">ID da tarefa a ser deletada</param>
        /// <returns>Retorna Ok se a tarefa for deletada; Se não, retorna NotFound</returns>
        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var success = await _TaskRepository.DeleteTaskAsync(id);
                return success ? Ok() : NotFound($"Tarefa com o Id: {id} não foi encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}