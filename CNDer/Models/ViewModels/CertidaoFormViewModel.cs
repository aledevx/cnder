using CNDer.Models;
using System.Collections.Generic;

namespace CNDer.Models.ViewModels
{
    public class CertidaoFormViewModel
    {
        public CertidaoFormViewModel(Servidor servidor, Tipo tipo){
            this.Servidor = servidor;
            this.Tipo = tipo;
        }
        public Servidor Servidor { get; set; }
        public ICollection<Objeto> Objeto { get; set; }
        public Tipo Tipo { get; set; }
    }
}