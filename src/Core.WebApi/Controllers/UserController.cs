using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.WebApi.Controllers {

    [Route ("api/user")]
    public class UserController : Controller {
        private readonly UserService _userService;

        public UserController (UserService userService) {
            _userService = userService;
        }

        [HttpPost ("login/{email}/{password}")]
        public UserModel Get (string email, string password) {
            var request = new UserModel (email, password);
            var response = _userService.Login (request);
            return response;
        }
    }
}