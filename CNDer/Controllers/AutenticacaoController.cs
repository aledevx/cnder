using CNDer.Services;
using CNDer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TiaIdentity;
using CNDer.Models;
using CNDer.ViewModels;

namespace Web.Controllers
{
   public class AutenticacaoController : Controller
    {
        private readonly Contexto db;
        private readonly ADService AD;
        private readonly Autenticador tiaIdentity;

        public AutenticacaoController(Contexto db, ADService aD, Autenticador tiaIdentity)
        {
            this.db = db;
            this.AD = aD;
            this.tiaIdentity = tiaIdentity;
        }

        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewmodel)
        {
            // if (!AD.LoginValido(viewmodel.Usuario, viewmodel.Senha))
            //     ModelState.AddModelError("CPF", "CPF ou Senha incorretos");

            if (ModelState.IsValid)
            {
                var usuario = await db.Usuarios.FirstOrDefaultAsync(a => a.CPF == viewmodel.Usuario);

                // if (usuario is null)
                // {
                //     var usuarioAD = AD.BuscarUsuario(viewmodel.Usuario);
                //     usuario = new Usuario();
                //     usuario.Perfil = "Inativo";
                //     await db.Usuarios.AddAsync(usuario);
                //     await db.SaveChangesAsync();
                // }
            
               await tiaIdentity.LoginAsync(usuario.CPF, usuario.Nome, usuario.Perfil, viewmodel.Lembrar);
                
                if (!string.IsNullOrWhiteSpace(viewmodel.ReturnUrl))
                    return Redirect(viewmodel.ReturnUrl);                

                return RedirectToAction("Index","Home");
            }
            return View();
        }      

        public async Task<IActionResult> Logout()
        {
            await tiaIdentity.LogoutAsync();
            return RedirectToAction("Login", "Autenticacao");
        }
    }
}