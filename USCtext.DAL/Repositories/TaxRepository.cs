using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.DataContext;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;

namespace USCtext.DAL.Repositories
{
    public class TaxRepository : IEntityRepository<Tax>
    {
        ApplicationContext db;

        public TaxRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Tax>> GetAllAsync()
        {
            return await db.Taxes.ToListAsync();
        }

        public async Task<Tax?> GetAsync(int id)
        {
            var result = await db.Taxes.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Tax?> CreateAsync(Tax entity)
        {
            var result = await db.Taxes.AddAsync(entity);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateAsync(Tax entity)
        {
            var tax = await GetAsync(entity.Id);

            if (tax != null)
            {
                tax.Flat = entity.Flat;

                tax.IsPayed = entity.IsPayed;

                tax.ColdWatherVolume = entity.ColdWatherVolume;
                tax.ColdWather = entity.ColdWather;

                tax.HotWatherVolume = entity.HotWatherVolume;
                tax.HotWather = entity.HotWather;

                tax.ElectricPowerVolume = entity.ElectricPowerVolume;
                tax.ElectricPower = entity.ElectricPower;

                db.Taxes.Update(tax);

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var tax = await GetAsync(id);

            db.Taxes.Remove(tax);

            await db.SaveChangesAsync();
        }
    }
}
