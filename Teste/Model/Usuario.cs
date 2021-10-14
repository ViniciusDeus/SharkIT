using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Usuario
    {
        public long Id { get; set; }
        public long Telefone { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        [Display(Name = "CPF")]
        public long Cpf { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "E-mail")]
        public String Email { get; set; }
        [Display(Name = "Endereço")]
        [MaxLength(200)]
        public String Endereco { get; set; }
    }
}