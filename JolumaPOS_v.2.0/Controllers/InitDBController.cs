using JolumaPOS_v._2._0.Data;
using JolumaPOS_v._2._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JolumaPOS_v._2._0.Controllers
{
    public class InitDBController : Controller
    {
        private readonly JolumaPOSDevContext _dbcontext;
        private readonly ApplicationDbContext _identitycontext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InitDBController(JolumaPOSDevContext dbcontext, ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbcontext = dbcontext;
            _identitycontext = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: InitDB
        public ActionResult Index()
        {
            //INTENTA MIGRAR LA INFORMACION A LA DB
            if (!InitDB.tryToMigrate(_dbcontext, _identitycontext))
            {
                Response.StatusCode = 500;
                var error = "Error interno del servidor. Contacte a su administrador.";

                return Json(error);
            }

            //INTENTA CREAR LOS USUARIOS ADMIN Y CAJERO
            if (!InitDB.tryCreateDefaultUsersAndRoles(_userManager, _roleManager))
            {
                Response.StatusCode = 500;
                var error = "Error interno del servidor. Contacte a su administrador.";

                return Json(error);
            }

            //INTENTA CREAR LOS USUARIOS ADMIN Y CAJERO
            if (!InitDB.trySeedDefaultData(_dbcontext))
            {
                Response.StatusCode = 500;
                var error = "Error interno del servidor. Contacte a su administrador.";

                return Json(error);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
