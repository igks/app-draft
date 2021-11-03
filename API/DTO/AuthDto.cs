//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication data transfer object
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
namespace API.DTO
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}