using BookManangementBO;
using BookManangementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRespository
{
    public class BorrowingHisRespository : IBorrowingHisRespository
    {
        public List<BorrowingHistory> GetAllBorrowingHis() => BorrowingHistoryDAO.Instance.GetAllBorrowingHistories();
        public BorrowingHistory GetBorrowingHisById(int id) => BorrowingHistoryDAO.Instance.GetBorrowingHistoryById(id);
        public void AddBorrowingHis(BorrowingHistory borrowingHis) => BorrowingHistoryDAO.Instance.AddBorrowingHistory(borrowingHis);
        public void UpdateBorrowingHis(BorrowingHistory borrowingHis) => BorrowingHistoryDAO.Instance.UpdateBorrowingHistory(borrowingHis);
        public void DeleteBorrowingHis(int id) => BorrowingHistoryDAO.Instance.DeleteBorrowingHistory(id);
        public List<BorrowingHistory> GetBorrowingHisByAccountID(int id) => BorrowingHistoryDAO.Instance.GetBorrowingHistoryByAccountId(id);
        public void BorrowBook(int accountId, int bookId) => BorrowingHistoryDAO.Instance.BorrowBook(accountId, bookId);
    }
}
