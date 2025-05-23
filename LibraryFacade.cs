using System.Collections.Generic;
using System.Linq;

namespace lab_2_0
{
    public interface ILibraryFacade
    {
        List<Book> SearchBooks(string query);
        bool BorrowBook(string isbn, string userId);
        bool ReturnBook(string isbn, string userId);
        List<User> GetAllUsers();
        User GetUserById(string userId);
    }

    public class LibraryFacade : ILibraryFacade
    {
        private readonly IBook _bookSearcher;
        private readonly List<User> _users;
        private readonly BorrowedBooksRegistry _borrowedBooks;
        public LibraryFacade(IBook bookSearcher, BorrowedBooksRegistry borrowedBooks)
        {
            _bookSearcher = bookSearcher;
            _users = User.GetAllUsers();
            _borrowedBooks = borrowedBooks;
        }

        public bool BorrowBook(string isbn, string userId)
        {
            List<Book> books = _bookSearcher.Search(isbn);
            Book foundBook = books.FirstOrDefault(b => b.ISBN == isbn);
            if (foundBook == null)
                return false;
            return _borrowedBooks.Borrow(foundBook, userId);
        }

        public bool ReturnBook(string isbn, string userId)
        {
            List<Book> books = _bookSearcher.Search(isbn);
            Book foundBook = books.FirstOrDefault(b => b.ISBN == isbn);
            if (foundBook == null)
                return false;
            return _borrowedBooks.Return(books, userId);
        }


    }
}
