//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Pagination header
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
namespace API.Helpers.Pagination
{
    public class PageHeader
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PageHeader(int currentPage, int PageSize, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.PageSize = PageSize;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}