using System.Collections.Generic;
using lab_2_0.Elements;

namespace lab_2_0.Book
{
    // Класс для хранения информации об одолженных книгах
    public class BorrowedBooksRegistry
    {
        private readonly Dictionary<string, string> _borrowedBooks = new Dictionary<string, string>(); // isbn -> userId

        public bool IsBorrowed(string isbn)
        {
            return _borrowedBooks.ContainsKey(isbn);
        }

        public bool Borrow(Book b, User u)
        {
            if (IsBorrowed(b.ISBN))
                return false;
            _borrowedBooks.Add(b.ISBN, u.Id);
            return true;
        }

        public bool Return(Book b, User u)
        {
            if (_borrowedBooks.ContainsKey(b.ISBN) && _borrowedBooks[b.ISBN] == u.Id)
            {
                _borrowedBooks.Remove(b.ISBN);
                return true;
            }
            return false;
        }
    }
}
