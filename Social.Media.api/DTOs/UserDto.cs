using System;

namespace Social.Media.api.DTOs;

public class UserDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
