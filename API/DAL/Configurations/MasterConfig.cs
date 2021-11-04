//===================================================
// Date         : 
// Author       : I Gusti Kade Sugiantara
// Description  : 
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DAL.Configurations
{
    public class MasterConfig : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder
                .HasMany<Detail>(x => x.Details)
                .WithOne(x => x.Master)
                .HasForeignKey(x => x.MasterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}