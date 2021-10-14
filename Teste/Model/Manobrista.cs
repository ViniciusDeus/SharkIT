using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Manobrista
    {
        public int idManobrista { get; set; }
        public string nome { get; set; }
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        public DateTime dtNascimento { get; set; }
    }
}
