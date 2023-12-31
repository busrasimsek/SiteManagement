﻿using SiteManagement.Data.Core.Repository.Abstract;
using System.Data;

namespace SiteManagement.Data.Core.UnitOfWork.Concrete
{
    public interface IUnitOfWork : IDisposable
    {
        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();       
        int SaveChanges();       
        Task<int> SaveChangesAsync();
        TRepo Repository<TRepo>() where TRepo : IBaseRepository;
    }
}
