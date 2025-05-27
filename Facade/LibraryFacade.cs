using lab_2_0.Book;
using lab_2_0.Elements;
using BookEntity = lab_2_0.Book.Book;

namespace lab_2_0.Facade
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
            List<BookEntity> books = _bookSearcher.Search(isbn);
            BookEntity? foundBook = books.Find(b => b.ISBN == isbn);
            User? foundUser = _users.Find(u => u.Id == userId);
            if (foundBook == null || foundUser == null)
                return false;
            return _borrowedBooks.Borrow(foundBook, foundUser);
        }

        public bool ReturnBook(string isbn, string userId)
        {
            List<BookEntity> books = _bookSearcher.Search(isbn);
            BookEntity? foundBook = books.Find(b => b.ISBN == isbn);
            User? foundUser = _users.Find(u => u.Id == userId);
            if (foundBook == null || foundUser == null)
                return false;
            return _borrowedBooks.Return(foundBook, foundUser);
        }
    }
}
