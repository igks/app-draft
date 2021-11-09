//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication data transfer object
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;

namespace API.DTO
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticatedUser
    {
        public string Token { get; set; }
        public DateTime TokenExpired { get; set; }

        public UserOut User { get; set; }
    }
}