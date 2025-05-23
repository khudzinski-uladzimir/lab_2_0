namespace lab_2_0
{
    public interface IBook
    {
        List<Book> Search(string query);
    }

    // Новый класс книги
    public class Book : IBook, IComponent
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public Book()
        {
            Title = "Test Book";
            Author = "Test Author";
            ISBN = "Test ISBN";
        }

        public List<Book> Search(string query)
        {
            return new List<Book>
            {
                new Book("Book 1", "Jon Skeet", "1234567890"),
                new Book("Book 2", "Adam Freeman", "0987654321"),
            };
        }

        public virtual string GetBookDescription()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}";
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
                new LegacyBook("Book 1", "Jon Skeet", "1234567890"),
                new LegacyBook("Book 2", "Adam Freeman", "0987654321"),
            };
        }
    }
}
