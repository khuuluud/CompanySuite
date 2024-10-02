﻿using LinkDev.CompanySuite.DAL.Models ;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {

        IEnumerable<T> GetAll(bool withAsNoTracking = false);

        IQueryable<T> GetAllAsIQueryable();

        T? GetById(int id);

        int Add(T entity);

        int Update(T entity);

        int Delete(T entity);

    }
}
