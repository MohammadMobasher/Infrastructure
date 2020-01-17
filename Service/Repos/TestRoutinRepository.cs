using DataLayer.DTO.Routine2;
using DataLayer.Entities;
using DataLayer.Interface.Routin2;
using DataLayer.SSOT.Routine2;
using DataLayer.ViewModels.Routine2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos
{
    public class TestRoutinRepository : GenericRepository<TestRoutin>
    {

        private readonly Routine2Repository _routine2Repository;

        public TestRoutinRepository(DatabaseContext db,
            Routine2Repository routine2Repository) : base(db)
        {
            _routine2Repository = routine2Repository;
        }

        

        public async Task<IEnumerable<dynamic>> getQuery()
        {
            return Entities;
        }
    }
}
