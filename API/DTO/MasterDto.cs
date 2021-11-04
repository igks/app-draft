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
    public class MasterIn
    {
        public long? Id { get; set; }

        public string MasterProperty1 { get; set; }

        public string MasterProperty2 { get; set; }

        public ICollection<DetailIn> Details { get; set; }
        public ICollection<CommonIn> Commons { get; set; }
    }

    public class MasterOut
    {
        public long Id { get; set; }

        public string MasterProperty1 { get; set; }

        public string MasterProperty2 { get; set; }

        public ICollection<DetailOut> Details { get; set; }
        public ICollection<CommonOut> Commons { get; set; }
    }
}