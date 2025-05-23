using System.Collections.Generic;

namespace lab_2_0
{
    // Класс для хранения информации об одолженных книгах
    public class BorrowedBooksRegistry
    {
        private readonly Dictionary<string, string> _borrowedBooks = new Dictionary<string, string>(); // isbn -> userId

        public bool IsBorrowed(string isbn)
        {
            return _borrowedBooks.ContainsKey(isbn);
        }

        public bool Borrow(Book b, string userId)
        {
            if (IsBorrowed(b.ISBN))
                return false;
            _borrowedBooks.Add(b.ISBN, userId);
            return true;
        }

        public bool Return(Book b, string userId)
        {
            if (_borrowedBooks.ContainsKey(b.ISBN) && _borrowedBooks[b.ISBN] == userId)
            {
                _borrowedBooks.Remove(b.ISBN);
                return true;
            }
            return false;
        }

        public string GetBorrower(string isbn)
        {
            if (_borrowedBooks.ContainsKey(isbn))
                return _borrowedBooks[isbn];
            return null;
        }
    }
}
