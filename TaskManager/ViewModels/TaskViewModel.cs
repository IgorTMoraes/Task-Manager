using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModels
{
    public class TaskViewModel
    {
        // ViewModel usado para receber dados na criação da tarefa
        public class CreateTaskViewModel
        {
            [MaxLength(100)]
            public string? Titulo { get; set; }

            [Required(ErrorMessage = "A descrição é obrigatoria.")]
            public string? Descricao { get; set; }

            public DateTime? DataLimite { get; set; }
        }

        // ViewModel usado para retornar dados da tarefa ao cliente
        public class TaskResponseViewModel
        {
            public Guid Id { get; set; }
            public string? Titulo { get; set; }
            public string? Descricao { get; set; }
            public DateTime? DataLimite { get; set; }
            public bool Concluida { get; set; }
        }
    }
}
