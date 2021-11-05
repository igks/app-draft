//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Application setting model
//===================================================
// Revision History:
// Name		        Date	        Description 	     
//                          		        		    
//===================================================

using MailKit.Security;

namespace API.Models
{
    public class Security
    {
        public string JWTSecretToken { get; set; }
    }

    public class ServerConfig
    {
        public string ADDomain { get; set; }
    }

    public class SystemConfig
    {
        public int Version { get; set; }
        public bool EnableAuthentication { get; set; }
        public bool EnableAuthorization { get; set; }
    }

    public class SmtpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public SecureSocketOptions Security { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
    }
}