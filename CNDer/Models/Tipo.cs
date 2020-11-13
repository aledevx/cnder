using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CNDer.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Tipo() { }

        public Tipo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}