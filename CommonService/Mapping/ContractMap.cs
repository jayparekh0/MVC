using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Mapping
{
    class ContractMap:EntityTypeConfiguration<Contract>
    {
        public ContractMap()
        {
            HasKey(foo => foo.ContractID);
            Property(foo => foo.FirstName).IsRequired();
            Property(foo => foo.LastName).IsRequired();
            Property(foo => foo.Email).IsRequired();
            Property(foo => foo.Phone).IsRequired();
            ToTable("Contracts");
        }
    }
}
