using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CNDer.Data;

namespace CNDer.Services
{
    public class GeradorDeListas
    {
        private readonly Contexto db;

        public GeradorDeListas(Contexto db)
        {
            this.db = db;
        }

    }
}