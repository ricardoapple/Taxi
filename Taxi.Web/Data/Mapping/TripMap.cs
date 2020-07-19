using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Models;

namespace Taxi.Web.Data.Mapping
{
    public class TripMap : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            _ = builder.ToTable("Trip");
            builder.HasKey(b => b.Id);

        }
    }
}