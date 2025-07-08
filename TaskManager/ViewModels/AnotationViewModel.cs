using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModels
{
    public class AnotationViewModel
    {
        // ViewModel usado para receber dados na criação da anotacao
        public class CreateAnotationViewModel 
        {
            [MaxLength(100)]
            public string? Titulo { get; set; }

            [Required(ErrorMessage = "O texto é obrigatorio.")]
            public string Texto { get; set; }
        }

        // ViewModel usado para retornar dados da anotacao ao cliente
        public class AnotationResponseViewModel 
        {
            public Guid Id { get; set; }
            public string Titulo { get; set; }  
            public string Texto { get; set; }
            public DateTime DataCriacao { get; set; }
        }
    }
}
