using lab_2_0.Adapter;
using lab_2_0.Book;
using BookEntity = lab_2_0.Book.Book;


namespace lab_2_0.Demo
{
    public class AdapterDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("Enter the search query:");
            string query = Console.ReadLine();

            // Создаём объект старой системы
            LegacyBook legacy = new();

            // Оборачиваем старую систему в адаптер и работаем через интерфейс IBookSearch
            IBook searcher = new LegacyBookSearcherAdapter(legacy);

            // Выполняем поиск
            List<BookEntity> results = searcher.Search(query);

            // Выводим результаты пользователю
            Console.WriteLine("Search result:");
            foreach (var b in results)
            {
                Console.WriteLine(b.GetBookDescription());
            }

        }
    }
}
