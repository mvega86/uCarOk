﻿using uCarOk.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uCarOk.Repositories.Interface
{
    public interface IRepository<T> where T : EntityBase, new()
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
