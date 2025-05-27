using lab_2_0.Book;
using BookEntity = lab_2_0.Book.Book;

namespace lab_2_0.Decorator
{
    public abstract class BookDecorator : BookEntity
    {
        protected BookEntity _book;

        protected BookDecorator(BookEntity book)
                        : base(book.Title, book.ISBN, book.Year, book.author.Name, book.author.Country, book.publisher.Name, book.publisher.City)

        {
            _book = book;
        }

        public override string GetBookDescription()
        {
            return _book.GetBookDescription();
        }
    }

    public class BookWithRating : BookDecorator
    {
        // Свойство рейтинга с дефолтным значением
        public double Rating { get; set; } = 0.0;

        public BookWithRating(BookEntity book)
            : base(book) { }

        public override string GetBookDescription()
        {
            return $"{base.GetBookDescription()}, Rating: {Rating}";
        }
    }

    public class BookWithWiewStatus : BookDecorator
    {
        // Свойство просмотра с дефолтным значением
        public bool ViewStatus { get; set; } = false;

        public BookWithWiewStatus(BookEntity book)
            : base(book) { }

        public override string GetBookDescription()
        {
            return $"{base.GetBookDescription()}, View Status: {ViewStatus}";
        }
    }
}
