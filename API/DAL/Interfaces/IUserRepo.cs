//===================================================
// Date         : 
// Author       : 
// Description  : User interface
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers.Pagination;
using API.Helpers.Params;
using API.Models;

namespace API.DAL.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task<PageList<User>> GetPage(UserParams parameter);
        void Add(User user, string password);
        void Update(User user, string password);
        void Delete(User user);
    }
}