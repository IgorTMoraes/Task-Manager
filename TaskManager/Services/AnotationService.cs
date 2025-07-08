using TaskManager.Data;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Services
{
    public class AnotationService
    {
        // Campo privado para o contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor com injeção de dependência do contexto
        public AnotationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Adiciona uma nova anotação ao banco de dados.
        public async Task<AnotationModel> AdicionarAsync(string texto, string? titulo = "")
        {
            // Cria uma nova instância de AnotationModel
            var anotacao = new AnotationModel(texto, titulo);
            // Gera manualmente um novo GUID para o ID da anotação
            anotacao.Id = Guid.NewGuid();

            // Adiciona ao banco (ainda não salva)
            _context.Anotations.Add(anotacao);
            // Salva no banco de dados
            await _context.SaveChangesAsync();
            return anotacao; // Retorna a anotação criada
        }

        // Lista todas as anotações existentes no banco.
        public async Task<List<AnotationModel>> ListarAsync()
        {
            // Retorna todas as anotações como uma lista
            return await _context.Anotations.ToListAsync();
        }

        // Retorna uma anotação específica pelo seu ID.
        public async Task<AnotationModel?> ObterPorIdAsync(Guid id)
        {
            // Busca no banco pela chave primária (ID)
            return await _context.Anotations.FindAsync(id);
        }

        // Remove uma anotação do banco de dados com base no ID
        // True se removido com sucesso, false se não encontrada.
        public async Task<bool> RemoverAsync(Guid id)
        {
            // Busca a anotação
            var anotacao = await _context.Anotations.FindAsync(id);
            if (anotacao == null) return false; // Se não encontrar, retorna falso

            // Remove do contexto
            _context.Anotations.Remove(anotacao);
            // Salva a alteração
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
