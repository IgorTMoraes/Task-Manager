using TaskManager.Models;

namespace TaskManager.Api.Services
{
    public interface ITaskService
    {
        Task<TaskModel> AdicionarAsync(string descricao, string titulo = "", DateTime? dataLimite = null);
        Task<List<TaskModel>> ListarAsync();
        Task<TaskModel?> ObterPorIdAsync(Guid id);
        Task<bool> MarcarComoConcluidaAsync(Guid id);
        Task<bool> RemoverAsync(Guid id);
    }
}
