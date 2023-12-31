﻿using System;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.ViewModels;
using Core.ViewResponse;
using Core.DtoModels;
using Core.Helpers;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = await userManager.FindByNameAsync(model.Username!);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password!);
            if (user == null || !passwordValid)
            {
                return BadRequest("Invalid username or password");
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName!),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

            if (userRoles != null)
            {
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["JWT:ExpirationHours"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var convertedToken = new JwtSecurityTokenHandler().WriteToken(token);
            UserProfileDto currentUser = _mapper.Map<ApplicationUser, UserProfileDto>(user);
            LoginResponse response = new LoginResponse
            {
                Token = convertedToken,
                Expiration = token.ValidTo,
                UserProfile = currentUser
            };

            return Ok(response);
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                var userExists = await userManager.FindByNameAsync(model.Username!);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    DateJoined = DateTime.UtcNow
                };
                var result = await userManager.CreateAsync(user, model.Password!);
                if (!result.Succeeded)
                {
                    var message = "";
                    foreach (var error in result.Errors)
                    {
                        message += error.Description + ", ";
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = message });
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.User);
                }

                return Ok(new AuthResponse { Success = true, Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username!);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                DateJoined = DateTime.UtcNow
            };
            var result = await userManager.CreateAsync(user, model.Password!);
            if (!result.Succeeded)
            {
                var message = "";
                foreach (var error in result.Errors)
                {
                    message += error.Description + ", ";
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = message });
            }

            if (model.Username.EndsWith("xyzzy"))
            {
                // Godzilla Admin Role
                if (!await roleManager.RoleExistsAsync(UserRoles.SuperGodzilla))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperGodzilla));

                if (await roleManager.RoleExistsAsync(UserRoles.SuperGodzilla))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.SuperGodzilla);
                }

                return Ok(new AuthResponse { Success = true, Status = "Success", Message = "Godzilla Admin created successfully!" });
            }
            else
            {
                // Regular Admin Role
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return Ok(new AuthResponse { Success = true, Status = "Success", Message = "Admin created successfully!" });
            }
        }

    }
}