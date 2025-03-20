using System;
using Social.Media.api.Entities;

namespace Social.Media.api.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
