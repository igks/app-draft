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

namespace API.DTO
{
    public class CommonIn
    {
        public long? Id { get; set; }

        public string CommonProperty1 { get; set; }

        public string CommonProperty2 { get; set; }
    }

    public class CommonOut
    {
        public long Id { get; set; }

        public string CommonProperty1 { get; set; }

        public string CommonProperty2 { get; set; }
    }

    public class CommonDto
    {
        public long MasterId { get; set; }

        public ICollection<CommonIn> CommonsIn { get; set; }
    }
}