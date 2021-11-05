//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Mailing interface
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Threading.Tasks;

namespace API.Helpers.Mailing
{
    public interface IEmailRepo
    {
        void SendNotification(EmailContent content);
    }
}