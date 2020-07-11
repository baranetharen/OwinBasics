using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicFormAuth.Models
{
    public class AccountRepository : IRepository<LoginViewModel>
    {
        readonly IList<LoginViewModel> storeData;
        public AccountRepository()
        {
            storeData = new List<LoginViewModel>()
            {
                new LoginViewModel(){ Password = "123456" ,UserName = "barane" }
            };
        }
        public void Add(LoginViewModel data)
        {
            storeData.Add(data);
        }

        public bool Comment()
        {
            return true;
        }

        public void Delete(LoginViewModel data)
        {
            var val = storeData.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
            if (val != null)
            {
                storeData.Remove(val);
            }
        }

        public LoginViewModel Find(int id)
        {
            return new LoginViewModel()
            {
                Password = "******",
                UserName = Convert.ToString(id)
            };
        }

        public IQueryable<LoginViewModel> FindAll()
        {
            return storeData.AsQueryable();
        }
    }
}