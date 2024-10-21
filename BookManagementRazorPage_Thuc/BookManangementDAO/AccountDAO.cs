using BookManangementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManangementDAO
{
    public class AccountDAO
    {
        private LibraryContext _context ;
        private static AccountDAO _instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
        }
        private AccountDAO()
        {
            _context = new LibraryContext();
        }
        public Account GetAccount(string username, string password)
        {
            return _context.Accounts.SingleOrDefault(a => a.Username == username && a.Password == password);
        }
        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.Where(a => a.RoleId == 2).ToList();
        }
        public bool deleteAccount(int id)
        {
            var accountToDelete = _context.Accounts.SingleOrDefault(a => a.AccountId == id);
            if (accountToDelete != null)
            {
                _context.Accounts.Remove(accountToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void updateAccount(Account account)
        {
            var accountToUpdate = _context.Accounts.SingleOrDefault(a => a.AccountId == account.AccountId);
            if (accountToUpdate != null)
            {
                accountToUpdate.Username = account.Username;
                accountToUpdate.Password = account.Password;
                accountToUpdate.RoleId = account.RoleId;
                _context.SaveChanges();
            }
        }
        public void addAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public Account getAccountById(int id)
        {
            return _context.Accounts.SingleOrDefault(a => a.AccountId == id);
        }
        public Account getAccountByRoleID(int? id)
        {
            return _context.Accounts.SingleOrDefault(a => a.RoleId == id);
        }
    }
}
