using System;
using System.Linq;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class RegistrationRepository : IRegistrationRepository<Registration>
    {
        ApplicationContext db;

        public RegistrationRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task CreateRegistrationAsync(Registration registration)
        {
            var user = db.UserProfiles.FirstOrDefault(u => u.Id == registration.UserId);

            if(user == null)
            {
                throw new Exception("Пользователя с id {registration.UserId} не существует");
            }

            var falt = db.Flats.FirstOrDefault(f => f.Id == registration.FlatId);

            if (falt == null)
            {
                throw new Exception("Квартиры с id {registration.UserId} не существует");
            }

            db.Registrations.Add(registration);
            await db.SaveChangesAsync();
        }

        public async Task UpdateRegistrtionAsync(Registration registration)
        {
            var updateReg = db.Registrations.FirstOrDefault(r => r.UserId == registration.UserId && r.FlatId == registration.FlatId);

            if (updateReg == null) 
            {
                throw new Exception("Данной регистрации не существует");
            }

            updateReg.RegistrationDate = registration.RegistrationDate;
            updateReg.RemoveDate = registration.RemoveDate;

            db.Registrations.Update(updateReg);
            await db.SaveChangesAsync();
        }
        public async Task DeleteRegistrationAsync(Registration registration)
        {
            var removeReg = db.Registrations.FirstOrDefault(r => r.UserId == registration.UserId && r.FlatId == registration.FlatId);

            if (removeReg == null)
            {
                throw new Exception("Данной регистрации не существует");
            }

            db.Registrations.Remove(removeReg);
            await db.SaveChangesAsync();
        }
    }
}
