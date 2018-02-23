using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    [Authorize(Roles =RolesNomes.ADMINISTRADOR)]
    public class UsuarioController : Controller
    {
        private UserManager<UsuarioAplicacao> _userManager;
        public UserManager<UsuarioAplicacao> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<UsuarioAplicacao>>();
                }
                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }
        
        public ActionResult Index()
        {
            var usuarios =
                UserManager
                    .Users
                    .ToList()
                    .Select(usuario => new UsuarioViewModel(usuario));

            return View(usuarios);
        }

        public ActionResult EditarFuncoes(string id)
        {
            return View();
        }
    }
}