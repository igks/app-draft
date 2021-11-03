//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : User data transfer object
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
namespace API.DTO
{
    public class UserInput
    {
        public int? Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserOutput
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}