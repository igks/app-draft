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
using API.DTO;
using API.Models;

namespace API.DAL.Interfaces
{
    public interface ICommonRepo
    {
        Task<Common> GetById(long id);
        Task<IList<long>> GetIdList(long masterId);
        void Add(CommonDto dto);
        Task Update(CommonDto dto);
        Task Delete(CommonDto dto);
    }
}