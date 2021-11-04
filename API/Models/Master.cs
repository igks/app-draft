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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MasterProperty1 { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MasterProperty2 { get; set; }

        public ICollection<Detail> Details { get; set; }
        public ICollection<Common> Commons { get; set; }
    }
}