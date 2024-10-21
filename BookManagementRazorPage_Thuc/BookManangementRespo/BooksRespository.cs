using BookManangementBO;
using BookManangementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRespository
{
    public class BooksRespository : IBooksRespository
    {
        public List<Book> GetAllBook() => BooksDAO.Instance.GetAllBooks();
        public Book GetBookById(int id) => BooksDAO.Instance.GetBookById(id);
        public void AddBook(Book book) => BooksDAO.Instance.AddBook(book);
        public void UpdateBook(Book book) => BooksDAO.Instance.UpdateBook(book);
        public void DeleteBook(int id) => BooksDAO.Instance.DeleteBook(id);
        public List<Book> GetAvailableBooksForAccount(int id) => BooksDAO.Instance.GetAvailableBooksForAccount(id);

    }
}
