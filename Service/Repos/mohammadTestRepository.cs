using Core.Utilities;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repos
{
    public class mohammadTestRepository : GenericRepository<mohammadTest>
    {
        public mohammadTestRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }


        public void ddd()
        {
            var d = GetById(1);
            d.SetPropertyValue("Title","2");
            DbContext.SaveChanges();
        }
    }
}
