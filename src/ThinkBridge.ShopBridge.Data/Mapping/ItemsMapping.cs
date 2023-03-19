using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data.Mapping
{
    public class ItemsMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(nameof(Item), schema: Constants.DATABASE_SCHEMA);
            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .UseHiLo();

            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder
                .Property(i => i.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(i => i.Price)
                .IsRequired();
        }
    }
}
