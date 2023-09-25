﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCtext.DAL.DataContext;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;

namespace USCtext.DAL.Repositories
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
            return await db.Flats.ToListAsync();
        }

        public async Task<Flat?> GetAsync(int id)
        {
            var result = await db.Flats.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

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
