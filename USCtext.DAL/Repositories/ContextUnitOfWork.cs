using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using USCtext.DAL.DataContext;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;

namespace USCtext.DAL.Repositories
{
    public class ContextUnitOfWork : IUnitOfWork
    {
        ApplicationContext db;

        FlatRepository FlatRepository { get; set; }
        TaxRepository TaxRepository { get; set; }
        UserManager<User> UserManager { get; set; }

        private bool disposed = false;

        public ContextUnitOfWork(UserManager<User> userManager)
        {
            db = new ApplicationContext();

            UserManager = userManager;
        }

        public ContextUnitOfWork(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;

            UserManager = userManager;
        }

        public IEntityRepository<Flat> Flats
        {
            get
            {
                if (FlatRepository == null)
                {
                    FlatRepository = new FlatRepository(db);
                }
                return FlatRepository;
            }
        }

        public IEntityRepository<Tax> Taxes
        {
            get
            {
                if (TaxRepository == null)
                {
                    TaxRepository = new TaxRepository(db);
                }
                return TaxRepository;
            }
        }

        public UserManager<User> Users
        {
            get
            {
                return UserManager;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
