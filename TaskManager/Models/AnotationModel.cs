using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class AnotationModel
    {
        // Identificador único da anotação (chave primária no banco de dados)
        [Key]
        public Guid Id { get; set; }

        // Campo obrigatório com no máximo 100 caracteres
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        // Campo obrigatório com a descrição da anotação
        [Required]
        public string Texto { get; set; }
        // Data da criação da anotação
        public DateTime DataCriacao { get; set; }

        // Construtor com parâmetros para inicializar a anotaçã com valores fornecidos
        // Se o título for vazio ou nulo, define como "Sem título"
        public AnotationModel(string texto, string titulo = "")
        {
            Titulo = string.IsNullOrWhiteSpace(titulo) ? "Sem título" : titulo;
            Texto = texto;
            DataCriacao = DateTime.Now;
        }

        // Construtor vazio necessário para o Entity Framework instanciar objetos automaticamente
        public AnotationModel() { }
    }
}
