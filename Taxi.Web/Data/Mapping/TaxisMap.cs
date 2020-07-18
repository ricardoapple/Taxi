using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Models;

namespace Taxi.Web.Data.Mapping
{
    public class TaxisMap : IEntityTypeConfiguration<Taxis>
    {
        public void Configure(EntityTypeBuilder<Taxis> builder)
        {
            _ = builder.ToTable("Taxis");
            builder.HasKey(b => b.Id);

        }
    }
}