﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmemIsaac.Blog.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);

        Task<IReadOnlyList<T>> ListAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
