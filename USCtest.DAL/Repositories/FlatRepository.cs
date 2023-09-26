using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class FlatRepository : IEntityRepository<Flat>
    {
        ApplicationContext db;

        public FlatRepository(ApplicationContext context) 
        {
            db = context;
        }

        public async Task<IEnumerable<Flat>> GetAllAsync()
        {
            return await db.Flats.Include(f => f.Users).Include(f => f.Taxes).ToListAsync();
        }

        public async Task<Flat?> GetAsync(int id)
        {
            var result = await db.Flats.Include(f => f.Users).Include(f => f.Taxes).AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Flat?> CreateAsync(Flat entity)
        {
            var result = await db.Flats.AddAsync(entity);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateAsync(Flat entity)
        {
            var flat = await GetAsync(entity.Id);

            if(flat != null)
            {
                flat.Street = entity.Street;
                flat.StreetNumber = entity.StreetNumber;
                flat.Building = entity.Building;
                flat.FlatNumber = entity.FlatNumber;

                flat.IsColdWatherDevice = entity.IsColdWatherDevice;
                flat.IsHotWatherDevice = entity.IsHotWatherDevice;
                flat.IsElectricPowerDevice = entity.IsElectricPowerDevice;

                flat.Taxes = entity.Taxes;
                flat.Users = entity.Users;

                db.Flats.Update(flat);

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var flat = await GetAsync(id);

            db.Flats.Remove(flat);

            await db.SaveChangesAsync();
        } 
    }
}
