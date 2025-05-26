using System.Collections.Generic;
using System.Linq;

namespace lab_2_0
{
    public interface ILibraryFacade
    {
        bool BorrowBook(string isbn, string userId);
        bool ReturnBook(string isbn, string userId);
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
            Book? foundBook = books.Find(b => b.ISBN == isbn);
            User? foundUser = _users.Find(u => u.Id == userId);
            if (foundBook == null || foundUser == null)
                return false;
            return _borrowedBooks.Borrow(foundBook, foundUser);
        }

        public bool ReturnBook(string isbn, string userId)
        {
            List<Book> books = _bookSearcher.Search(isbn);
            Book? foundBook = books.Find(b => b.ISBN == isbn);
            User? foundUser = _users.Find(u => u.Id == userId);
            if (foundBook == null || foundUser == null)
                return false;
            return _borrowedBooks.Return(foundBook, foundUser);
        }
    }
}
