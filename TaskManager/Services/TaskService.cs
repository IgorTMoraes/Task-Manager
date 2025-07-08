using TaskManager.Models;
using TaskManager.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Services
{
    public class TaskService
    {
        // Injeção de dependência do contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor recebe o contexto via injeção de dependência
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Cria uma nova tarefa e salva no banco de dados.
        public async Task<TaskModel> AdicionarAsync(string descricao, string titulo = "", DateTime? dataLimite = null)
        {
            var task = new TaskModel(descricao, titulo, dataLimite); // Cria uma nova instância de TaskModel
            _context.Tasks.Add(task); // Adiciona ao contexto (ainda não salva no banco)
            await _context.SaveChangesAsync(); // Salva no banco
            return task; // Retorna a tarefa criada
        }

        // Retorna todas as tarefas cadastradas.
        public async Task<List<TaskModel>> ListarAsync()
        {
            return await _context.Tasks.ToListAsync(); // Retorna todas as tarefas como uma lista
        }

        // Retorna uma tarefa pelo seu ID.
        public async Task<TaskModel?> ObterPorIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id); // Procura a tarefa pelo ID no banco
        }

        // Marca uma tarefa como concluída.
        // True se marcada com sucesso, false se não encontrada
        public async Task<bool> MarcarComoConcluidaAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id); // Procura a tarefa
            if (task == null) return false; // Se não existir, retorna falso

            task.Concluida = true; // Marca como concluída
            await _context.SaveChangesAsync(); // Salva a alteração
            return true;
        }

        // Remove uma tarefa do banco de dados.
        // True se removida com sucesso, false se não encontrada
        public async Task<bool> RemoverAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id); // Procura a tarefa
            if (task == null) return false; // Se não existir, retorna falso

            _context.Tasks.Remove(task); // Remove a tarefa do contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco
            return true;
        }
    }
}





/*
namespace TaskManager.Services
{
    public class TaskService 
    {
        private readonly List<TaskModel> _tasks = new();

        public TaskModel Adicionar(string descricao, string titulo = "", DateTime? dateLimite = null) 
        {
            var task = new TaskModel(descricao, titulo, dateLimite);
            _tasks.Add(task);
            return task;
        }

        public List<TaskModel> Lista() 
        { 
            return _tasks; 
        }

        public bool MarcarComoConcluida(Guid id) 
        { 
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) 
            { 
                return false;
            }

            task.Concluida = true;
            return true;
        }

        public bool Remover(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }

            _tasks.Remove(task);
            return true;
        }
    }
}
*/
/*
namespace TaskManager.Services
{
    public class TaskService
    {
        private List<TaskModel> task = new();

        public void Adicionar(string descricao) 
        {
            task.Add(new TaskModel(descricao));
        }

        public List<TaskModel> Listar()
        { 
            return task; 
        }

        public bool MarcarComoConcluida(int indice) 
        {
            if (indice == 0)
            {
                task[indice].Concluida = true;
                return true;
            }
            return false;
        }
    }
}
*/


