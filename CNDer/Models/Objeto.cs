using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CNDer.Enums;

namespace CNDer.Models
{
    public class Objeto
    {
        [Key]
        public int Id { get; set; }
        public Servidor Servidor { get; set; }
        [Display(Name = "Servidor")]
        public int ServidorId { get; set; }
        [Display(Name = "Nº do processo SEI!")]
        [Required(ErrorMessage = "Informe o número do processo")]
        public string NumeroSei { get; set; }
        public Tipo Tipo { get; set; }
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }
        [Display(Name = "Número")]
        public string NumeroTipo { get; set; }
        public string Penalidade { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        [Display(Name = "Data de inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]        
        public System.DateTime? DataInicio { get; set; }
        [Display(Name = "Data final")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public System.DateTime? DataFim { get; set; }
        public bool? StatusAtivo { get; set; }

        public Objeto() { }

        public Objeto(int id,
         Servidor servidor,
          string numeroSei,
           Tipo tipo,
           string numeroTipo,
            string penalidade,
             string descricao,
              DateTime? dataInicio,
               DateTime? dataFim,
                 Boolean statusAtivo)
        {
            Id = id;
            Servidor = servidor;
            NumeroSei = numeroSei;
            Tipo = tipo;
            NumeroTipo = numeroTipo;
            Penalidade = penalidade;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            StatusAtivo = statusAtivo;
        }

    }
}