using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CNDer.Data;

namespace CNDer.Models
{
    public class Servidor
    {
        public int Id { get; set; }
        [Display(Name = "Servidor")]
        [Required(ErrorMessage = "o campo Nome não pode ficar em branco")]
        public string Nome { get; set; }

        [Display(Name = "Nº CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 digitos")]
        [Required(ErrorMessage = "o campo CPF não pode ficar em branco")]

        public string Cpf { get; set; }
        [Display(Name = "Nº Matrícula")]
        [Required(ErrorMessage = "o campo Matrícula não pode ficar em branco")]
        public string Matricula { get; set; }
        public ICollection<Objeto> Objetos { get; set; }
        
        // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        // {

        //     var result = Contexto.Servidores.Count(s = s.Cpf == Cpf);
        //     if (result > 0)
        //     {
        //         yield return new ValidationResult("Esse cpf ja está cadastrado", new string[] { "Cpf" });
        //     }

        // }

        public Servidor()
        {
        }

        public Servidor(int id, string nome, string cpf, string matricula)
        {
            Nome = nome;
            Cpf = cpf;
            Matricula = matricula;
        }

        public void AddObjeto(Objeto objeto)
        {
            Objetos.Add(objeto);
        }


    }
}