using System;
using Microsoft.EntityFrameworkCore;
using tcc.api.Data;
using tcc.api.Models;
using tcc.api.Repositories.Interfaces;

namespace tcc.api.Repositories
{
    public class EntityRepository : IDbRepository<EntityModel>
    {
        private readonly DataContext _dbContext;

        public EntityRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<EntityModel>> GetItems()
        {
            var result = await _dbContext.Entities.AsNoTracking().ToListAsync();
            return result;
        }

        public EntityModel Insert(EntityModel item)
        {
            throw new NotImplementedException();
        }

        public string ResetDB()
        {
            throw new NotImplementedException();
        }

    }
}
