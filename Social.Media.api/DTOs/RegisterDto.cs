using System;
using System.ComponentModel.DataAnnotations;

namespace Social.Media.api.DTOs;

public class RegisterDto
{
    [Required]
    public required string Username { get; set; }
    public required string Password { get; set; }
}
