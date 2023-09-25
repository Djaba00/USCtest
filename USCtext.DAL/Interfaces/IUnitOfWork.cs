using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.Entities;

namespace USCtext.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<Flat> Flats { get; }
        IEntityRepository<Tax> Taxs { get; }
        UserManager<User> UserManager { get; }

        Task SaveAsync();
    }
}
