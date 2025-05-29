using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social.Media.api.Data;
using Social.Media.api.DTOs;
using Social.Media.api.Entities;
using Social.Media.api.Interfaces;

namespace Social.Media.api.Controllers;

public class AccountController(DataContext context, ITokenService tokenService): BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        return Ok();
        //using var hmac = new HMACSHA512();

        //var user = new AppUser
        //{
        //    UserName = registerDto.Username.ToLower(),
        //    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //    PasswordSalt = hmac.Key
        //};

        //context.Users.Add(user);
        //await context.SaveChangesAsync();

        //return new UserDto
        //{
        //    Username = user.UserName,
        //    Token = tokenService.CreateToken(user)
        //};
    }
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

        if (user == null) return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        if (user.PasswordHash == null || user.PasswordSalt == null || user.PasswordHash.Length == 0 || user.PasswordSalt.Length == 0)
        {
            return Unauthorized("Invalid password - user data incomplete");
        }


        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }

        return new UserDto
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}
