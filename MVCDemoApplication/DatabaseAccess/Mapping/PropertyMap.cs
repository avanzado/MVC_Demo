using System.Data.Entity.ModelConfiguration;
using Framework.Domain;

namespace DataAccess.Mapping
{
    public partial class PropertyMap : EntityTypeConfiguration<Property>
    {
        public PropertyMap()
        {
            this.ToTable("PropertyMaster");
            this.HasKey(a => a.Id);
                        
            this.Property(a => a.PropertyName);

            this.Property(a => a.PropertyDescription);

            this.Property(a => a.LastModifiedUserID);
               
        }
    }
}
