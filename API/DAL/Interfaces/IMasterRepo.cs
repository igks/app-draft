//===================================================
// Date         : 
// Author       : 
// Description  : 
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
    public interface IMasterRepo
    {
        Task<Master> GetById(long id);
        Task<IEnumerable<Master>> GetAll();
        Task<PageList<Master>> GetPage(MasterParams parameter);
        void Add(Master master);
        void Update(Master master);
        void Remove(Master master);
    }
}