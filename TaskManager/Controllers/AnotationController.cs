using Microsoft.AspNetCore.Mvc;
using TaskManager.ViewModels;
using TaskManager.Models;
using AutoMapper;
using static TaskManager.ViewModels.AnotationViewModel;
using TaskManager.Api.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnotationController : ControllerBase
    {
        // Lista estática de anotações (não está sendo usada neste contexto)
        private static readonly List<AnotationModel> _anotacoes = new();

        // Dependências: serviço de anotações e AutoMapper
        private readonly IAnotationService _anotationService;
        private readonly IMapper _mapper;

        // Construtor com injeção de dependência
        public AnotationController(IAnotationService anotationService, IMapper mapper)
        {
            _anotationService = anotationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CreateAnotationViewModel viewModel)
        {
            // Verifica se o modelo enviado é válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Chama o serviço para adicionar a anotação
            var anotacao = await _anotationService.AdicionarAsync(viewModel.Texto, viewModel.Titulo);
            // Mapeia o resultado para um ViewModel de resposta
            var response = _mapper.Map<AnotationResponseViewModel>(anotacao);

            // Retorna 201 Created com a rota para obter a anotação recém-criada
            return CreatedAtAction(nameof(ObterPorId), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await _anotationService.ListarAsync();
            // Mapeia a lista de modelos para uma lista de ViewModels de resposta
            var response = _mapper.Map<List<AnotationResponseViewModel>>(lista);
            return Ok(response); // Retorna 200 OK com a lista de anotações
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var anotacao = await _anotationService.ObterPorIdAsync(id);
            if (anotacao == null) return NotFound();  // Retorna 404 caso não encontre

            // Mapeia para ViewModel de resposta
            var response = _mapper.Map<AnotationResponseViewModel>(anotacao);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var sucesso = await _anotationService.RemoverAsync(id);
            return sucesso ? NoContent() : NotFound(); // Retorna 204 No Content se sucesso ou 404 se não encontrou
        }
    }
}