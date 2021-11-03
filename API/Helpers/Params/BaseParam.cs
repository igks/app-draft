//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Base param class
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
namespace API.Helpers.Params
{
    public class BaseParam
    {
        private const int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string OrderBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}