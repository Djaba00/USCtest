using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFlatRepository<Flat> Flats { get; }
        ITaxRepository<Tax> Taxes { get; }
        IUserProfileRepository<UserProfile> UserProfiles { get; }
        IRegistrationRepository<Registration> Registrations { get; }
        UserManager<ApplicationUser> Accounts { get; }

        Task SaveAsync();
    }
}
