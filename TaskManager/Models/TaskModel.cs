using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskModel
    {
        // Identificador único da tarefa (chave primária no banco de dados)
        [Key]
        public Guid Id { get; set; }

        // Campo obrigatório com no máximo 100 caracteres
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        // Campo obrigatório com a descrição da tarefa
        [Required]
        public string Descricao { get; set; }

        // Data limite opcional para a tarefa (pode ser nula)
        public DateTime? DataLimite { get; set; }

        // Indica se a tarefa foi concluída (padrão: false)
        public bool Concluida { get; set; }

        // Construtor com parâmetros para inicializar a tarefa com valores fornecidos
        // Se o título for vazio ou nulo, define como "Sem título"
        public TaskModel(string descricao, string titulo = "", DateTime? dataLimite = null)
        {
            Titulo = string.IsNullOrWhiteSpace(titulo) ? "Sem título" : titulo;
            Descricao = descricao;
            DataLimite = dataLimite;
            Concluida = false;
        }

        // Construtor vazio necessário para o Entity Framework instanciar objetos automaticamente
        public TaskModel() { }
    }
}
