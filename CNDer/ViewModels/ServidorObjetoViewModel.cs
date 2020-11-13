using CNDer.Models;
using System.Collections.Generic;

namespace CNDer.ViewModels
{
    public class ServidorObjetoViewModel
    {
        public Servidor Servidor { get; set; }
        public ICollection<Objeto> Objeto { get; set; }
    }
}