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
        IEntityRepository<Flat> Flats { get; }
        IEntityRepository<Tax> Taxes { get; }
        UserManager<User> UsersManager { get; }

        Task SaveAsync();
    }
}
