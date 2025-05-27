using lab_2_0.Composite;
using lab_2_0.Flyweight;

namespace lab_2_0.Book
{
    public interface IBook
    {
        List<Book> Search(string query);
    }

    // Новый класс книги
    public class Book : IBook, IComponent
    {
        public string Title { get; }
        public string ISBN { get; }
        public int Year { get; private set; }

        // Это ссылки на легковесы (внутреннее состояние)
        public readonly Author author;
        public readonly Publisher publisher;

        public Book(string title, string isbn, int year,
                         string authorName, string authorCountry,
                         string publisherName, string publisherCity)
        {
            Title = title;
            ISBN = isbn;
            Year = year;

            // Получаем автора и издательство через фабрики
            author = AuthorFactory.GetAuthor(authorName, authorCountry);
            publisher = PublisherFactory.GetPublisher(publisherName, publisherCity);
        }

        public List<Book> Search(string query)
        {
            return new List<Book>
            {
                new("Book 1","34564565", 1991, "unknown", "unknown", "unknown", "unknown")
            };
        }

        public void ShowBookInfo()
        {
            Console.WriteLine($"Book: {Title} ({Year})");
            Console.WriteLine($"ISBN: {ISBN}");

            // Передаем внешнее состояние в методы легковесов
            author.ShowInfo(Title);
            publisher.ShowInfo(Title, Year);
            Console.WriteLine("---");
        }

        public virtual string GetBookDescription()
        {
            return $"Title: {Title}, ISBN: {ISBN}";
        }

        // Реализация интерфейса IComponent
        public void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + GetBookDescription());
        }
    }

    public interface ILegacyBook
    {
        List<LegacyBook> FindBooksByKeyword(string keyword);
    }

    // Старый класс книги
    public class LegacyBook : ILegacyBook
    {
        public string Title { get; }
        public string AuthorName { get; }
        public string Code { get; }

        public LegacyBook(string title, string authorName, string code)
        {
            Title = title;
            AuthorName = authorName;
            Code = code;
        }

        public LegacyBook()
        {
            Title = "Test Book";
            AuthorName = "Test Author";
            Code = "Test Code";
        }

        public List<LegacyBook> FindBooksByKeyword(string keyword)
        {
            return new List<LegacyBook>
            {
                new LegacyBook("Book 1", "Jon Skeet", "1234567890")
            };
        }
    }
}
