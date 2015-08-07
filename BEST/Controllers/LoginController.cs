using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BEST.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BEST.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/Registro
        [AllowAnonymous]
        public ActionResult Registro()
        {
            return View();
        }

        //
        // POST: /Login/Registro
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro(LoginModel model)
        {
            int id_empresa = model.M_empresa.ObtenerCorrelativo();
            int id_usuario = model.M_usuario.ObtenerCorrelativo(id_empresa);

            model.M_empresa.id_empresa = id_empresa;
            model.M_empresa.razon_social = model.M_empresa.nombre_comercial;
            model.M_empresa.direccion = ".";
            model.M_empresa.email = model.M_usuario.correo;
            model.M_empresa.telefono = ".";
            model.M_empresa.fecha_registro = DateTime.Now;
            model.M_empresa.estado = "A";

            model.M_usuario.id_empresa = id_empresa;
            model.M_usuario.id_usuario = id_usuario;
            model.M_usuario.fecha_registro = DateTime.Now;
            model.M_usuario.estado = "A";

            model.M_usuario_password.id_usuario_password = model.M_usuario_password.ObtenerCorrelativo(id_empresa, id_usuario);
            model.M_usuario_password.id_empresa = id_empresa;
            model.M_usuario_password.id_usuario = id_usuario;
            model.M_usuario_password.fecha_registro = DateTime.Now;
            model.M_usuario_password.estado = "A";


            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.M_usuario.nombre};
                var result = await UserManager.CreateAsync(user, model.confirmarcontraseña);
                
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("",error);
            }
        }
	}
}