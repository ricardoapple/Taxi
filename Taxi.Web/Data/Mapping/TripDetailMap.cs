using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Models;

namespace Taxi.Web.Data.Mapping
{
    public class TripDetailMap : IEntityTypeConfiguration<TripDetail>
    {
        public void Configure(EntityTypeBuilder<TripDetail> builder)
        {
            _ = builder.ToTable("TripDetail");
            builder.HasKey(b => b.Id);

        }
    }
}