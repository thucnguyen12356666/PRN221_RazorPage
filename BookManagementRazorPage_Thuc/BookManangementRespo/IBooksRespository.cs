using BookManangementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRespository
{
    public interface IBooksRespository
    {
        public List<Book> GetAllBook();
        public Book GetBookById(int id);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
        public List<Book> GetAvailableBooksForAccount(int id);
    }
}
