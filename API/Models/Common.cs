//===================================================
// Date         : 
// Author       : 
// Description  : 
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long MasterId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string CommonProperty1 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string CommonProperty2 { get; set; }

    }
}