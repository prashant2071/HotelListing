using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly UserManager<ApiUser> _userManager;



        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            //SignInManager<ApiUser> signInManager,
            UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            //_signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)  
        {
            _logger.LogInformation($"Register attempt for {userDTO.Email}");
            if (!ModelState.IsValid) //model validation or form validation like Required
            {
                return BadRequest(ModelState);
    
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user,userDTO.password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong is {nameof(Register)}");
                return Problem($"something went wrong in{nameof(Register)}",statusCode:500);
            }
        }

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        //{
        //    _logger.LogInformation($"Register attempt for {userDTO.Email}");
        //    if (!ModelState.IsValid) //model validation or form validation like Required
        //    {
        //        return BadRequest(ModelState);

        //    }
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.password,
        //            false, false);

        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(userDTO);
        //        }
        //        return Accepted();
                
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, $"Something went wrong is {nameof(Login)}");
        //        return Problem($"something went wrong in{nameof(Login)}", statusCode: 500);
        //    }
        //}

    }
}
