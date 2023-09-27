using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository<UserProfile>
    {
        ApplicationContext db;

        public UserProfileRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await db.UserProfiles
                .Include(u => u.Registrations)
                    .ThenInclude(r => r.Flat)
                .Include(u => u.ApplicationUser)
                .ToListAsync();
        }

        public async Task<UserProfile> GetAsync(int id)
        {
            var result = await db.UserProfiles
                .Include(u => u.Registrations)
                    .ThenInclude(r => r.Flat)
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<UserProfile> CreateAsync(UserProfile entity)
        {
            var result = await db.UserProfiles.AddAsync(entity);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateAsync(UserProfile entity)
        {
            var user = await GetAsync(entity.Id);

            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.MiddleName = entity.MiddleName;
                user.PassportSeries = entity.PassportSeries;
                user.PassportNumber = entity.PassportNumber;

                //user.Flats = entity.Flats;
                user.Registrations = entity.Registrations;
                user.ApplicationUser = entity.ApplicationUser;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetAsync(id);

            db.UserProfiles.Remove(user);

            await db.SaveChangesAsync();
        }
    }
}
