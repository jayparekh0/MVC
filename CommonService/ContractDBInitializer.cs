using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CommonService
{
    public class ContractDBInitializer : DropCreateDatabaseAlways<TableContext>
    {
        protected override void Seed(TableContext context)
        {
            IList<Data.Status> defaultRecord = new List<Data.Status>();
            defaultRecord.Add(new Data.Status()
            {
                StatusID= 1,
                StatusDesc= "Active"
            });
            defaultRecord.Add(new Data.Status()
            {
                StatusID = 2,
                StatusDesc = "Inactive"
            });
            context.Entry(defaultRecord[0]).State = EntityState.Added;
            context.Entry(defaultRecord[1]).State = EntityState.Added;
            base.Seed(context);
        }
    }
}
