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
        ILibraryFacade library = new LibraryFacade(searcher);

        // Поиск книг через фасад
        var foundBooks = library.SearchBooks(query);
        Console.WriteLine("Books found via Facade:");
        foreach (var b in foundBooks)
        {
            Console.WriteLine(b.GetBookDescription());
        }

        // Получение пользователей
        var users = library.GetAllUsers();
        Console.WriteLine("Users:");
        foreach (var u in users)
        {
            Console.WriteLine(u.Id + ": " + u.Name);
        }

        // Оформление и возврат книги
        if (foundBooks.Count > 0 && users.Count > 0)
        {
            var bookToBorrow = foundBooks[0];
            var user = users[0];
            bool borrowed = library.BorrowBook(bookToBorrow.ISBN, user.Id);
            if (borrowed)
            {
                Console.WriteLine("Book '" + bookToBorrow.Title + "' borrowed by " + user.Name);
            }
            else
            {
                Console.WriteLine("Book '" + bookToBorrow.Title + "' could not be borrowed");
            }

            bool returned = library.ReturnBook(bookToBorrow.ISBN, user.Id);
            if (returned)
            {
                Console.WriteLine("Book '" + bookToBorrow.Title + "' returned by " + user.Name);
            }
            else
            {
                Console.WriteLine("Book '" + bookToBorrow.Title + "' could not be returned");
            }
        }
    }
}
