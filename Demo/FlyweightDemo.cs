using lab_2_0.Flyweight;
using BookEntity = lab_2_0.Book.Book;

namespace lab_2_0.Demo
{
    internal class FlyweightDemo
    {
        public static void RunDemo()
        {
            List<BookEntity> books =
            [
                // Books by Author1, publisher Publisher1
                new BookEntity("Book1", "111111", 2019, "Author1", "England", "Publisher1", "New York"),
                new BookEntity("Book2", "222222", 2020, "Author1", "England", "Publisher1", "New York"),
                new BookEntity("Book3", "333333", 2021, "Author1", "England", "Publisher1", "New York"),

                // Books by Author2, publisher Publisher2
                new BookEntity("Book4", "444444", 2008, "Author2", "USA", "Publisher2", "Boston"),
                new BookEntity("Book5", "555555", 2018, "Author2", "USA", "Publisher2", "Boston"),

                // More books: Author1 + another publisher, new author + Publisher1
                new BookEntity("Book6", "666666", 2022, "Author1", "England", "Publisher3", "California"),
                new BookEntity("Book7", "777777", 2020, "Autho3", "USA", "Publisher1", "New York"),
             ];
             
            Console.WriteLine("Information about all books:");
            foreach (var book in books)
            {
                book.ShowBookInfo();
            }

            // Show the effectiveness of the pattern
            Console.WriteLine($"\nTotal books created: {books.Count}");
            Console.WriteLine($"Total Author objects created: {AuthorFactory.GetAuthorsCount()}");
            Console.WriteLine($"Total Publisher objects created: {PublisherFactory.GetPublishersCount()}");  
        }
    }
}
