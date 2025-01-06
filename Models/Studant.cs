using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ErickTest.Models;

public class Studant
{
    [Key]
    [DisplayName("Id")]
    public  int id { get; set; }

    [Required(ErrorMessage = "Informe seu nome")]
    [StringLength(100, ErrorMessage = "O nome deve conter no máximo, 100 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter, no mínimo, 5 caracteres")]
    [DisplayName("Nome Completo")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [DisplayName("E-mail")]
    public string? Email { get; set; }

    public List<Premium> Premiums { get; set; } = new();

}

