using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Net;

namespace ErickTest.Models;

public class Premium
{
    [Key]
    [DisplayName("Id")]
    public int id { get; set; }

    [Required(ErrorMessage = "Informe o título do premium")]
    [StringLength(100, ErrorMessage = "O título deve conter no máximo 100 caracteres")]
    [MinLength(5, ErrorMessage = "O título deve conter, no mínimo, 5 caracteres")]
    [DisplayName("Título")]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    [GreaterThanToday]
    [DisplayName("Início")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayName("Termino")]
    public DateTime EndDate { get; set; }

    [DisplayName("Aluno")]
    [Required(ErrorMessage = "Aluno inválido")]
    public int StudantId { get; set; }

    public Studant? Studant { get; set; }
}
