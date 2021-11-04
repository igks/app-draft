//===================================================
// Date         : 
// Author       : 
// Description  : 
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
namespace API.DTO
{
    public class DetailIn
    {
        public string DetailProperty1 { get; set; }

        public string DetailProperty2 { get; set; }
    }

    public class DetailOut
    {
        public long Id { get; set; }

        public string DetailProperty1 { get; set; }

        public string DetailProperty2 { get; set; }
    }
}