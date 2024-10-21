using BookManangementBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManangementDAO
{
    public class BorrowingHistoryDAO
    {
        private LibraryContext _context;
        private static BorrowingHistoryDAO _instance = null;
        public static BorrowingHistoryDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BorrowingHistoryDAO();
                }
                return _instance;
            }
        }
        private BorrowingHistoryDAO()
        {
            _context = new LibraryContext();
        }
        public List<BorrowingHistory> GetAllBorrowingHistories()
        {
            return _context.BorrowingHistories.ToList();
        }
        public BorrowingHistory GetBorrowingHistoryById(int id)
        {
            return _context.BorrowingHistories.SingleOrDefault(b => b.BorrowId == id);
        }
        public void AddBorrowingHistory(BorrowingHistory borrowingHistory)
        {
            _context.BorrowingHistories.Add(borrowingHistory);
            _context.SaveChanges();
        }
        public void UpdateBorrowingHistory(BorrowingHistory borrowingHistory)
        {
            var borrowingHistoryToUpdate = _context.BorrowingHistories.SingleOrDefault(b => b.BorrowId == borrowingHistory.BorrowId);
            if (borrowingHistoryToUpdate != null)
            {
                borrowingHistoryToUpdate.BorrowDate = borrowingHistory.BorrowDate;
                borrowingHistoryToUpdate.ReturnDate = borrowingHistory.ReturnDate;
                borrowingHistoryToUpdate.AccountId = borrowingHistory.AccountId;
                borrowingHistoryToUpdate.BookId = borrowingHistory.BookId;
                _context.SaveChanges();
            }
        }
        public void DeleteBorrowingHistory(int id)
        {
            var borrowingHistoryToDelete = _context.BorrowingHistories.SingleOrDefault(b => b.BorrowId == id);
            if (borrowingHistoryToDelete != null)
            {
                _context.BorrowingHistories.Remove(borrowingHistoryToDelete);
                _context.SaveChanges();
            }
        }
        public List<BorrowingHistory> GetBorrowingHistoryByAccountId(int accountId)
        {
            return _context.BorrowingHistories.Include(b => b.Book).Where(b => b.AccountId == accountId).ToList();

        }
        public void BorrowBook(int accountId, int bookId)
        {
            
            var borrowingHistory = new BorrowingHistory
            {
                AccountId = accountId,
                BookId = bookId,
                BorrowDate = DateTime.Now, 
                ReturnDate = DateTime.Now.AddDays(5)
            };

            
            _context.BorrowingHistories.Add(borrowingHistory);
            _context.SaveChanges(); 
        }
    }
}
