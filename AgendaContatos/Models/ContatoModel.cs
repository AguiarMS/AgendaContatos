using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o E-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é invalido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Insira uma observação do contato")]
        public string Observacao { get; set; }
    }
}
