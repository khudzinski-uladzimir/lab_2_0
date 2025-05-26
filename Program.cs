using System.Runtime.InteropServices;
using System.Security.Cryptography;
using lab_2_0;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the search query:");
        string query = Console.ReadLine();

        // Создаём объект старой системы
        LegacyBook legacy = new LegacyBook();

        // Оборачиваем старую систему в адаптер и работаем через интерфейс IBookSearch
        IBook searcher = new LegacyBookSearcherAdapter(legacy);

        // Выполняем поиск
        List<Book> results = searcher.Search(query);

        // Выводим результаты пользователю
        Console.WriteLine("Search result:");
        foreach (var b in results)
        {
            Console.WriteLine(b.GetBookDescription());
        }

        Book book = new Book("Test Book", "Test Author", "Test ISBN");
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


        Console.WriteLine("\n\n");

        // Создаём категории
        var fiction = new BookCategory("Fiction");
        var spaceOpera = new BookCategory("Cosmo-opera");
        var cyberpunk = new BookCategory("Cyberpunk");

        // Добавляем подкатегории
        fiction.AddComponent(spaceOpera);
        fiction.AddComponent(cyberpunk);

        // Добавляем книги
        spaceOpera.AddComponent(new Book("Dune", "Frank Herbert", "978-5-17-118366-4"));
        cyberpunk.AddComponent(new Book("Lord of the Rings", "J.J. Tolkien", "978-5-699-97309-5"));

        fiction.Display();


        // --- Простая демонстрация фасада ---
        Console.WriteLine("\n--- Facade Pattern Demo ---");
        BorrowedBooksRegistry registry = new BorrowedBooksRegistry();
        ILibraryFacade library = new LibraryFacade(searcher, registry);
        // Добавляем пользователей
        User.AddUser(new User("user1", "John Doe"));
        User.AddUser(new User("user2", "Jane Smith"));

        // Оформление и возврат книги        
        Console.WriteLine(library.BorrowBook("1234567890", "user1"));
        Console.WriteLine(registry.IsBorrowed("1234567890"));
        Console.WriteLine(library.ReturnBook("1234567890", "user1"));
        Console.WriteLine(registry.IsBorrowed("1234567890"));
    }
}
