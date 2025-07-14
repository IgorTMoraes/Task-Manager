using TaskManager.Models;

namespace TaskManager.Api.Services
{
    public interface IAnotationService
    {
        Task<AnotationModel> AdicionarAsync(string texto, string? titulo = "");
        Task<List<AnotationModel>> ListarAsync();
        Task<AnotationModel?> ObterPorIdAsync(Guid id);
        Task<bool> RemoverAsync(Guid id);
    }
}
