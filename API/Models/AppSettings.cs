//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Application setting model
//===================================================
// Revision History:
// Name		        Date	        Description 	     
//                          		        		    
//===================================================

namespace CVB.CSI.Models
{
    public class Security
    {
        public string JWTSecretToken { get; set; }
    }

    public class ServerConfig
    {
        public string ADDomain { get; set; }
    }
}