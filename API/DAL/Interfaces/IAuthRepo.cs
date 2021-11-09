//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication interface
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Threading.Tasks;
using API.DTO;
using API.Models;

namespace API.DAL.Interfaces
{
    public interface IAuthRepo
    {
        Task<AuthenticatedUser> Login(string username, string password);
        void Register(User user, string password);
    }
}