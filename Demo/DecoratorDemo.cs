using lab_2_0.Decorator;
using BookEntity = lab_2_0.Book.Book;

namespace lab_2_0.Demo
{
    internal class DecoratorDemo
    {
        public static void RunDemo()
        {
            BookEntity book = new("Test Book", "34564565", 1991, "unknown", "unknown", "unknown", "unknown");
            Console.WriteLine(book.GetBookDescription());
            Console.WriteLine("\n\n");


            // Создаём экземпляр класса BookWithRating и BookWithWiewStatus
            BookWithRating bookWithRating = new BookWithRating(book);

            // Устанавливаем рейтинг
            Console.WriteLine("Enter the desired rating for the book:");
            bookWithRating.Rating = 4.5;
            Console.WriteLine(bookWithRating.GetBookDescription());
            BookWithWiewStatus bookWithWiewStatus = new BookWithWiewStatus(bookWithRating);
            Console.WriteLine("\n\n");

            // Устанавливаем статус просмотра
            Console.WriteLine("Is this book read?:");
            bookWithWiewStatus.ViewStatus = true;
            Console.WriteLine(bookWithWiewStatus.GetBookDescription());
        }

    }
}
