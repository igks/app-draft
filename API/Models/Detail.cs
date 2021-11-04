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
    public class Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long MasterId { get; set; }
        public Master Master { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DetailProperty1 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DetailProperty2 { get; set; }
    }
}