using System;
using CNDer.Models;

namespace CNDer.Helpers
{
    public class CalculosHelper
    {
        public static TimeSpan DuracaoPenalidade(Objeto objeto)
        {
            DateTime dataFim = Convert.ToDateTime(objeto.DataFim);
            DateTime dataInicio = Convert.ToDateTime(objeto.DataInicio);

            TimeSpan duracao = dataFim.Subtract(dataInicio);

            return duracao;
        }
        public static TimeSpan DiasRestantesPenalidade(Objeto objeto)
        {
            DateTime dataFim = Convert.ToDateTime(objeto.DataFim);
            DateTime dataAtual = System.DateTime.Now;

            TimeSpan tempoRestante = dataFim.Subtract(dataAtual);

            return tempoRestante;
        }
    }
}