namespace lab_2_0
{
    // Адаптер: преобразует вызовы IBook в вызовы LegacyBook
    public class LegacyBookSearcherAdapter : IBook
    {
        private readonly ILegacyBook _legacySearcher;

        public LegacyBookSearcherAdapter(ILegacyBook legacySearcher)
        {
            _legacySearcher = legacySearcher;
        }

        public List<Book> Search(string query)
        {
            // Получаем список LegacyBook из старой системы
            List<LegacyBook> legacyBooks = _legacySearcher.FindBooksByKeyword(query);

            // Преобразуем каждый LegacyBook в новый объект Book
            List<Book> books = new List<Book>();
            foreach (var lb in legacyBooks)
            {
                // Создаём новый объект Book на основе данных из LegacyBook
                Book book = new Book(lb.Title, lb.AuthorName, lb.Code);
                books.Add(book);
            }

            return books;
        }
    }
}
