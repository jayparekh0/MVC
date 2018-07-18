using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Mapping
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            HasKey(foo => foo.StatusID);
            Property(foo => foo.StatusDesc).IsRequired();
            ToTable("Status");
        }
    }
}
