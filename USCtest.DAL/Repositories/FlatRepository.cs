using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class FlatRepository : IFlatRepository<Flat>
    {
        ApplicationContext db;

        public FlatRepository(ApplicationContext context) 
        {
            db = context;
        }

        public async Task<IEnumerable<Flat>> GetAllAsync()
        {
            return await db.Flats
                .Include(f => f.Taxes)
                .Include(f => f.Registrations)
                    .ThenInclude(r => r.User)
                .ToListAsync();
        }

        public async Task<Flat> GetByIdAsync(int id)
        {
            var result = await db.Flats
                .Include(f => f.Taxes)
                .Include(f => f.Registrations)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<Flat>> GetByAddress(string name)
        {
            var result = await db.Flats
                .Include(f => f.Taxes)
                .Include(f => f.Registrations)
                    .ThenInclude(r => r.User)
                .Where(x => x.GetFullAddress().Contains(name))
                .ToListAsync();

            return result;
        }

        public async Task<Flat> CreateAsync(Flat entity)
        {
            var result = await db.Flats.AddAsync(entity);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateAsync(Flat entity)
        {
            var flat = await GetByIdAsync(entity.Id);

            if(flat != null)
            {
                flat.Street = entity.Street;
                flat.StreetNumber = entity.StreetNumber;
                flat.Building = entity.Building;
                flat.FlatNumber = entity.FlatNumber;

                flat.IsColdWaterDevice = entity.IsColdWaterDevice;
                flat.IsHotWaterDevice = entity.IsHotWaterDevice;
                flat.IsElectricPowerDevice = entity.IsElectricPowerDevice;

                flat.Taxes = entity.Taxes;
                //flat.Users = entity.Users;

                db.Flats.Update(flat);

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var flat = await GetByIdAsync(id);

            db.Flats.Remove(flat);

            await db.SaveChangesAsync();
        } 
    }
}
