using System;

namespace Social.Media.api.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
}
