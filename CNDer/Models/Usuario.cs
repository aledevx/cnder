using System;

namespace CNDer.Models
{
public class Usuario
    {
        public Usuario(){}
        public Usuario(string cpf, string nome, string perfil = Perfis.Usuario)
        {
            this.CPF = cpf;
            this.Nome = AbreviarNome(nome);
            this.Perfil = perfil;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Perfil { get; set; } 

        private string AbreviarNome(string nomeCompleto)
        {
            var array = nomeCompleto.Split(' ');
            var primeiroNome = array[0];
            var nomeAbreviado = primeiroNome;
            
            if (array.Length > 1)            {
                var ultimoNome = array[array.Length-1];                            
                nomeAbreviado += " " + ultimoNome;
            }

            return nomeAbreviado;
        }
    }
}