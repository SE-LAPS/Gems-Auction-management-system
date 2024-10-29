﻿using backend.Dto.Account;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("backend/account")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/ or Password incorrect");

            return Ok(
                new NewUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try 
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber
                };

                var createUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                PhoneNumber = user.PhoneNumber,
                                Token = _tokenService.CreateToken(user)
                            }
                            );
                    }else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                } else
                {
                    return StatusCode(500, createUser.Errors);
                }
            } 
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) return NotFound("User not found");

                return Ok(new NewUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Token = _tokenService.CreateToken(user)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
