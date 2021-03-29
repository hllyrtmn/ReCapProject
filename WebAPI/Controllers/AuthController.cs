using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var userToken = _authService.CreateAccessToken(userToLogin.Data);
            if (!userToken.Success)
            {
                return BadRequest(userToken.Message);
            }

            return Ok(userToken.Data);

        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);

            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var tokenResult = _authService.CreateAccessToken(registerResult.Data);

            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult.Message);
            }

            return Ok(tokenResult.Data);
        }




    }
}
