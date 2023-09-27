using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class TaxRepository : ITaxRepository<Tax>
    {
        ApplicationContext db;

        public TaxRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Tax>> GetAllAsync()
        {
            return await db.Taxes
                .Include(t => t.Flat)
                .ToListAsync();
        }

        public async Task<Tax> GetAsync(int id)
        {
            var result = await db.Taxes
                .Include(t => t.Flat)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Tax> CreateAsync(Tax entity)
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

                tax.Date = entity.Date;
                tax.IsPayed = entity.IsPayed;

                tax.ColdWatherVolume = entity.ColdWatherVolume;
                tax.ColdWatherCost = entity.ColdWatherCost;

                tax.HotWatherHeatVolume = entity.HotWatherHeatVolume;
                tax.HotWatherHeatCost = entity.HotWatherHeatCost;

                tax.HotWatherThermalEnergyVolume = entity.HotWatherThermalEnergyVolume;
                tax.HotWatherThermalEnergyCost = entity.HotWatherThermalEnergyCost;

                tax.ElectricPowerVolume = entity.ElectricPowerVolume;
                tax.ElectricityDayVolume = entity.ElectricityDayVolume;
                tax.ElectricityNightVolume = entity.ElectricityNightVolume;
                tax.ElectricPowerCost = entity.ElectricPowerCost;

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
