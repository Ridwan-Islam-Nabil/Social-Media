using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social.Media.api.Data;
using Social.Media.api.DTOs;
using Social.Media.api.Entities;
using Social.Media.api.Interfaces;

namespace Social.Media.api.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public UsersController(IUserRepository _userRepository, IMapper _mapper)
    {
        userRepository = _userRepository;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();

        var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(usersToReturn);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetUserByNameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return mapper.Map<MemberDto>(user);
    }
}
