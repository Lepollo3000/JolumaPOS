using JolumaPOS_v2.Server.Data;
using JolumaPOS_v2.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JolumaPOS_v2.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserFirstNameController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _identitycontext;
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;
        

        public UserFirstNameController(UserManager<ApplicationUser> userManager, ApplicationDbContext identitycontext, AuthenticationStateProvider oAuthenticationStateProvider)
        {
            _userManager = userManager;
            _identitycontext = identitycontext;
            _AuthenticationStateProvider = oAuthenticationStateProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //var userName = User.Identity.Name;

            var oUser = (await _AuthenticationStateProvider.GetAuthenticationStateAsync()).User;

            var user = await _userManager.GetUserAsync(User);

            if (user != null)
                return StatusCode(200, user.FirstName + " " + user.LastName);

            return null;
        }
    }
}
