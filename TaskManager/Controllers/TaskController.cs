using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;
using TaskManager.ViewModels;
using static TaskManager.ViewModels.TaskViewModel;
using TaskManager.Models;
using AutoMapper;
using TaskManager.Api.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        // Construtor com injeção de dependência do serviço e do AutoMapper
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        // Cria uma nova tarefa
        [HttpPost]
        public async Task<IActionResult> Criar(CreateTaskViewModel viewModel)
        {
            // Valida se os dados recebidos são válidos (conforme DataAnotations)
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapeia o ViewModel recebido para o modelo de domínio
            var model = _mapper.Map<TaskModel>(viewModel);
            // Adiciona a nova tarefa via serviço
            var novaTarefa = await _taskService.AdicionarAsync(model.Descricao, model.Titulo, model.DataLimite);

            // Mapeia o resultado de volta para um ViewModel de resposta
            var response = _mapper.Map<TaskResponseViewModel>(novaTarefa);
            // Retorna 201 Created com a URL para obter essa tarefa
            return CreatedAtAction(nameof(ObterPorId), new { id = response.Id }, response);
        }

        // Retorna todas as tarefas cadastradas.
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await _taskService.ListarAsync();
            // Converte a lista de modelos para lista de ViewModels de resposta
            var response = _mapper.Map<List<TaskResponseViewModel>>(lista);
            return Ok(response); // Retorna 200 OK com a lista
        }

        // Retorna uma tarefa específica pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var tarefa = await _taskService.ObterPorIdAsync(id);
            if (tarefa == null) return NotFound(); // Retorna 404 se não encontrada

            var response = _mapper.Map<TaskResponseViewModel>(tarefa);
            return Ok(response); // Retorna 200 OK com a tarefa
        }

        // Marca uma tarefa como concluída
        [HttpPut("{id}/concluir")]
        public async Task<IActionResult> MarcarComoConcluida(Guid id)
        {
            var sucesso = await _taskService.MarcarComoConcluidaAsync(id);
            return sucesso ? Ok() : NotFound(); // 200 OK ou 404 Not Found
        }

        // Remove uma tarefa pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var sucesso = await _taskService.RemoverAsync(id);
            return sucesso ? NoContent() : NotFound(); // 204 No Content ou 404 Not Found
        }
    }
}
/*
[HttpPost]
public IActionResult Criar(CreateTaskViewModel viewModel)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var model = _mapper.Map<TaskModel>(viewModel);
    var novaTarefa = _taskService.Adicionar(model.Descricao, model.Titulo, model.DataLimite);

    var response = _mapper.Map<TaskResponseViewModel>(novaTarefa);
    return CreatedAtAction(nameof(ObterPorId), new { id = response.Id }, response);
}

[HttpGet]
public IActionResult Listar()
{
    var lista = _taskService.Listar();
    var response = _mapper.Map<List<TaskResponseViewModel>>(lista);
    return Ok(response);
}

[HttpGet("{id}")]
public IActionResult ObterPorId(Guid id)
{
    var tarefa = _taskService.Listar().FirstOrDefault(t => t.Id == id);
    if (tarefa == null) return NotFound();

    var response = _mapper.Map<TaskResponseViewModel>(tarefa);
    return Ok(response);
}

[HttpPut("{id}/concluir")]
public IActionResult MarcarComoConcluida(Guid id)
{
    var sucesso = _taskService.MarcarComoConcluida(id);
    return sucesso ? Ok() : NotFound();
}

[HttpDelete("{id}")]
public IActionResult Remover(Guid id)
{
    var sucesso = _taskService.Remover(id);
    return sucesso ? NoContent() : NotFound();
}
*/
