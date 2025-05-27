using lab_2_0.Adapter;
using lab_2_0.Book;
using lab_2_0.Elements;
using lab_2_0.Facade;

namespace lab_2_0.Demo
{
    internal class FacadeDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("Facade pattern");

            LegacyBook legacy = new LegacyBook();

            // Оборачиваем старую систему в адаптер и работаем через интерфейс IBookSearch
            IBook searcher = new LegacyBookSearcherAdapter(legacy);

            BorrowedBooksRegistry registry = new();

            // Создаем фасад для управления библиотекой
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
}
