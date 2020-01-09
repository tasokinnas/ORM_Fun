// <copyright file="IRepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DapperSample.Contracts
{
    using System;
    using System.Collections.Generic;

    interface IRepository<T>
    {
        List<T> GetAll();
        //bool Add(T entity);
        //T GetById(Guid id);
        //bool Update(T entity);
        //bool Delete(Guid id);
    }
}
