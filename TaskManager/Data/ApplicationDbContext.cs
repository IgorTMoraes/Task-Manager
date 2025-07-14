using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Models;

namespace TaskManager.Data
{
    // Representa o contexto do banco de dados
    // Responsável por configurar e mapear os modelos (entidades) para as tabelas do banco
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do contexto
        // Isso permite injetar a string de conexão e outras configurações pelo sistema de injeção de dependência
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        // Representa a tabela de tarefas no banco de dados
        // Cada item em Tasks corresponde a uma instância de TaskModel
        public DbSet<TaskModel> Tasks { get; set; }
        // Representa a tabela de anotações no banco de dados
        // Cada item em Anotations corresponde a uma instância de AnotationModel
        public DbSet<AnotationModel> Anotations { get; set; }
    }  
}
