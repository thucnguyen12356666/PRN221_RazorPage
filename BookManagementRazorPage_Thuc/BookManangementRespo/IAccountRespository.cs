using BookManangementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRespository
{
    public interface IAccountRespository
    {
        public Account GetAccount(string username, string password);
        public List<Account> GetAllAccounts();
        public bool deleteAccount(int id);
        public void updateAccount(Account account);
        public void addAccount(Account account);
        public Account getAccountById(int id);
        public Account getAccountByRoleID(int? id);
    }
}
