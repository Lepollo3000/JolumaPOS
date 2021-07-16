using JolumaPOS_v._2._0.Data;
using JolumaPOS_v._2._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JolumaPOS_v._2._0
{
    public class InitDB
    {
        public static bool tryToMigrate(JolumaPOSDevContext dbcontext, ApplicationDbContext identitycontext)
        {
            try
            {
                identitycontext.Database.Migrate();
                dbcontext.Database.Migrate();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool tryCreateDefaultUsersAndRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string strAdminRole = "Administrador";
            string strCajeroRole = "Cajero";

            string strAdminEmail = "usuario.admin@gmail.com";
            string strAdminPassword = "Pa55w.rd";
            string strAdminFirstName = "Usuario";
            string strAdminLastName = "Aministrador";

            string strCajeroEmail = "usuario.cajero@gmail.com";
            string strCajeroPassword = "Pa55w.rd";
            string strCajeroFirstName = "Usuario";
            string strCajeroLastName = "Promedio";

            if (!(tryCreateRoleIfNotExist(roleManager, strAdminRole) && tryCreateRoleIfNotExist(roleManager, strCajeroRole)))
            {
                return false;
            }

            tryCreateUserIfNotExistsAndAddRole(userManager, strAdminEmail, strAdminPassword, strAdminRole, strAdminFirstName, strAdminLastName);
            tryCreateUserIfNotExistsAndAddRole(userManager, strCajeroEmail, strCajeroPassword, strCajeroRole, strCajeroFirstName, strCajeroLastName);

            return true;
        }

        public static bool trySeedDefaultData(JolumaPOSDevContext dbcontext)
        {
            try
            {
                CreateInventarioStatusIfNotExists(dbcontext, 1, "En proceso");
                CreateInventarioStatusIfNotExists(dbcontext, 2, "Cancelada");
                CreateInventarioStatusIfNotExists(dbcontext, 3, "Concretado");

                CreateVentaStatusIfNotExists(dbcontext, 1, "En proceso");
                CreateVentaStatusIfNotExists(dbcontext, 2, "Cancelada");
                CreateVentaStatusIfNotExists(dbcontext, 3, "Pago en Proceso");
                CreateVentaStatusIfNotExists(dbcontext, 4, "Pagada");

                CreateTipoMonedaIfNotExists(dbcontext, 1, "MXN");
                CreateTipoMonedaIfNotExists(dbcontext, 2, "USD");

                CreateTipoPagoIfNotExists(dbcontext, 1, "Débito");
                CreateTipoPagoIfNotExists(dbcontext, 2, "Tarjeta");

                CreateUnidadMedidaIfNotExists(dbcontext, 1, "pza.");
                CreateUnidadMedidaIfNotExists(dbcontext, 2, "g.");
                CreateUnidadMedidaIfNotExists(dbcontext, 3, "ml.");

                CreateCategoriaIfNotExists(dbcontext, 1, null, "Bebidas");
                CreateCategoriaIfNotExists(dbcontext, 2, 1, "Refrescos");
                CreateCategoriaIfNotExists(dbcontext, 3, null, "Snacks");
                CreateCategoriaIfNotExists(dbcontext, 2, null, "Comidas");

                CreateContactoTipoIfNotExists(dbcontext, 1, "Contacto");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool tryCreateRoleIfNotExist(RoleManager<IdentityRole> roleManager, string strRole)
        {
            try
            {
#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
                IdentityRole? oRole = roleManager.FindByNameAsync(strRole).Result;
#pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

                if (oRole == null)
                {
                    oRole = new IdentityRole();
                    oRole.Name = strRole;
                    oRole.Id = Guid.NewGuid().ToString();
                    
                    roleManager.CreateAsync(oRole).Wait();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool tryCreateUserIfNotExistsAndAddRole(UserManager<ApplicationUser> userManager, string strEmail, string strPassword, string strRole, string strFirstName, string strLastName)
        {
            try
            {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
                ApplicationUser? oUser = userManager.FindByNameAsync(strEmail).Result;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
                if (oUser == null)
                {
                    oUser = new ApplicationUser() {
                        Id = Guid.NewGuid().ToString(),
                        UserName = strEmail,
                        Email = strEmail,
                        EmailConfirmed = true,
                        FirstName = strFirstName,
                        LastName = strLastName,
                        Lockout = false
                    };

                    userManager.CreateAsync(oUser, strPassword).Wait();
                }

                if (oUser != null)
                    userManager.AddToRoleAsync(oUser, strRole).Wait();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static InventarioStatus CreateInventarioStatusIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.InventarioStatuses.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                InventarioStatus o = new InventarioStatus()
                {
                    Descripcion = descripcion
                };

                dbcontext.InventarioStatuses.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static VentaStatus CreateVentaStatusIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.VentaStatuses.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                VentaStatus o = new VentaStatus()
                {
                    Descripcion = descripcion
                };

                dbcontext.VentaStatuses.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static TipoMonedum CreateTipoMonedaIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.TipoMoneda.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                TipoMonedum o = new TipoMonedum()
                {
                    Descripcion = descripcion
                };

                dbcontext.TipoMoneda.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static TipoPago CreateTipoPagoIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.TipoPagos.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                TipoPago o = new TipoPago()
                {
                    Descripcion = descripcion
                };

                dbcontext.TipoPagos.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static UnidadMedidum CreateUnidadMedidaIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.UnidadMedida.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                UnidadMedidum o = new UnidadMedidum()
                {
                    Descripcion = descripcion
                };

                dbcontext.UnidadMedida.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static Categorium CreateCategoriaIfNotExists(JolumaPOSDevContext dbcontext, int Id, int? padre, string descripcion)
        {
            var obj = dbcontext.Categoria.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                Categorium o = new Categorium()
                {
                    Padre = padre,
                    Descripcion = descripcion,
                    Status = true
                };

                dbcontext.Categoria.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }

        private static ContactoTipo CreateContactoTipoIfNotExists(JolumaPOSDevContext dbcontext, int Id, string descripcion)
        {
            var obj = dbcontext.ContactoTipos.Where(x => x.Id == Id);

            if (!obj.Any())
            {
                ContactoTipo o = new ContactoTipo()
                {
                    Descripcion = descripcion
                };

                dbcontext.ContactoTipos.Add(o);
                dbcontext.SaveChanges();

                return o;
            }

            return null;
        }
    }
}
