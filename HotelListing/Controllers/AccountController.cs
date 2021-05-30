using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using HotelListing.services;
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
        private readonly UserManager<ApiUser> _userManager;
        private readonly IAuthManager _authmanager;



        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper, 
            UserManager<ApiUser> userManager,
            IAuthManager authmanager)
        {
            _mapper = mapper;
            _logger = logger;
            _authmanager = authmanager;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Register attempt for {userDTO.Email}");
            if (!ModelState.IsValid) //model validation or form validation like Required
            {
                return BadRequest(ModelState);

            }
            try
            {
                if (!await _authmanager.validateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authmanager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

    }
}
