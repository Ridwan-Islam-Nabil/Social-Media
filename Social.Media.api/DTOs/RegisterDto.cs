using System;
using System.ComponentModel.DataAnnotations;

namespace Social.Media.api.DTOs;

public class RegisterDto
{
    [Required] public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(8, MinimumLength = 3)]
    public string Password { get; set; } = string.Empty;
}
