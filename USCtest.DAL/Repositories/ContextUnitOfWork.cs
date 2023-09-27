using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;

namespace USCtest.DAL.Repositories
{
    public class ContextUnitOfWork : IUnitOfWork
    {
        ApplicationContext db;

        FlatRepository FlatRepository { get; set; }
        TaxRepository TaxRepository { get; set; }
        UserProfileRepository UserProfileRepository { get; set; }
        UserManager<ApplicationUser> AccountManager { get; set; }

        private bool disposed = false;

        public ContextUnitOfWork(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;

            AccountManager = userManager;
        }

        public IFlatRepository<Flat> Flats
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

        public ITaxRepository<Tax> Taxes
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

        public UserManager<ApplicationUser> Accounts
        {
            get
            {
                return AccountManager;
            }
        }

        public IUserProfileRepository<UserProfile> UserProfiles
        {
            get
            {
                if (UserProfileRepository == null)
                {
                    UserProfileRepository = new UserProfileRepository(db);
                }
                return UserProfileRepository;
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
