using BookManangementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRespository
{
    public  interface IBorrowingHisRespository
    {
        public List<BorrowingHistory> GetAllBorrowingHis();
        public BorrowingHistory GetBorrowingHisById(int id);
        public void AddBorrowingHis(BorrowingHistory borrowingHis);
        public void UpdateBorrowingHis(BorrowingHistory borrowingHis);
        public void DeleteBorrowingHis(int id);
        public List<BorrowingHistory> GetBorrowingHisByAccountID(int id);
        public void BorrowBook(int accountId, int bookId);
    }
}
