using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicFormAuth.Models
{
    public interface IRepository<T>
    {
        void Add(T data);
        void Delete(T data);
        T Find(int id);
        IQueryable<T> FindAll();
        bool Comment();
 
    }
}