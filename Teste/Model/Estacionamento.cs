using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Estacionamento
    {
        [Display(Name = "ID")]
        public int idEstacionamento { get; set; }
        public int idCarro { get; set; }
        public Carro carro { get; set; }
        public int idManobristaEntrada { get; set; }
        public Manobrista manobristaEntrada { get; set; }
        [Display(Name = "Data Entrada")]
        public DateTime dtEntrada { get; set; }

        [Display(Name = "Data Saída")]
        public DateTime dtSaida { get; set; }
        public int idManobristaSaida { get; set; }

        public Manobrista manobristaSaida { get; set; }

    }
}
