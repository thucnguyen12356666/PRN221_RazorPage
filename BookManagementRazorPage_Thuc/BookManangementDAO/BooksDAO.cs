using BookManangementBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManangementDAO
{
    public class BooksDAO
    {
        private  LibraryContext _context;
        private static BooksDAO _instance = null;
        public static BooksDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BooksDAO();
                }
                return _instance;
            }
        }
        private BooksDAO()
        {
            _context = new LibraryContext();
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return _context.Books.SingleOrDefault(b => b.BookId == id);
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book)
        {
            var bookToUpdate = _context.Books.SingleOrDefault(b => b.BookId == book.BookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Publisher = book.Publisher;
                bookToUpdate.YearPublished = book.YearPublished;
                bookToUpdate.Quantity = book.Quantity;
                _context.SaveChanges();
            }
        }
        public void DeleteBook(int id)
        {
            
            var borrowingsToDelete = _context.BorrowingHistories.Where(b => b.BookId == id).ToList();

           
            if (borrowingsToDelete.Any())
            {
                _context.BorrowingHistories.RemoveRange(borrowingsToDelete);
            }

            
            var bookToDelete = _context.Books.SingleOrDefault(b => b.BookId == id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
        }

        public List<Book> GetAvailableBooksForAccount(int accountId)
        {
            var borrowedBookIds = _context.BorrowingHistories.Include(b => b.Book)
                                           .Where(b => b.AccountId == accountId)
                                           .Select(b => b.BookId)
                                           .ToList();
            return _context.Books
                           .Where(book => !borrowedBookIds.Contains(book.BookId))
                           .ToList();
        }

    }
}
