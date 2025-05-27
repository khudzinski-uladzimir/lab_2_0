using lab_2_0.Decorator;
using BookEntity = lab_2_0.Book.Book;

namespace lab_2_0.Demo
{
    internal class DecoratorDemo
    {
        public static void RunDemo()
        {
            BookEntity book = new("Test Book", "34564565", 1991, "unknown", "unknown", "unknown", "unknown");
            Console.WriteLine("Original book:");
            Console.WriteLine(book.GetBookDescription());
            Console.WriteLine();

            // Добавляем рейтинг
            BookWithRating bookWithRating = new BookWithRating(book);
            bookWithRating.Rating = 4.5;
            Console.WriteLine("Book with rating:");
            Console.WriteLine(bookWithRating.GetBookDescription());
            Console.WriteLine();

            // Добавляем статус просмотра К КНИГЕ С РЕЙТИНГОМ
            BookWithWiewStatus bookWithViewStatus = new BookWithWiewStatus(bookWithRating);
            bookWithViewStatus.ViewStatus = true;
            Console.WriteLine("Book with rating and view status:");
            Console.WriteLine(bookWithViewStatus.GetBookDescription());
        }

    }
}
