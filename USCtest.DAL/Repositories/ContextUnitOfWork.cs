﻿using Microsoft.AspNetCore.Identity;
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
        UserManager<User> UserManager { get; set; }

        private bool disposed = false;

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

        public UserManager<User> UsersManager
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