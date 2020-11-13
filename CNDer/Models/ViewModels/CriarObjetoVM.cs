namespace CNDer.Models.ViewModels
{
    public class CriarObjetoVM
    {
        public Servidor Servidor { get; set; }
        public int ServidorId { get; set; }
        public string NumeroSei { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }
        public string Penalidade { get; set; }
        public string Descricao { get; set; }
        public System.DateTime? DataInicio { get; set; }
        public System.DateTime? DataFim { get; set; }

    }
}