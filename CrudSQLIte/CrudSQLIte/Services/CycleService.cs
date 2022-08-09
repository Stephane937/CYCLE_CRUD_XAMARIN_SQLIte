using CrudSQLIte.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CrudSQLIte.Services
{
    public class CycleService
    {
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<CycleModel>> GetAllCycles()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Cycles.ToListAsync();
            return res;
        }

        public async Task<int> UpdateCycle(CycleModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Cycles.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertCycle(CycleModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Cycles.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteCycle(CycleModel obj)
        {

            var _dbContext = getContext();
            _dbContext.Cycles.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
