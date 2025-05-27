using lab_2_0.Book;
using BookEntity = lab_2_0.Book.Book;



namespace lab_2_0.Adapter
{
    // Адаптер: преобразует вызовы IBook в вызовы LegacyBook
    public class LegacyBookSearcherAdapter : IBook
    {
        private readonly ILegacyBook _legacySearcher;

        public LegacyBookSearcherAdapter(ILegacyBook legacySearcher)
        {
            _legacySearcher = legacySearcher;
        }

        public List<BookEntity> Search(string query)
        {
            // Получаем список LegacyBook из старой системы
            List<LegacyBook> legacyBooks = _legacySearcher.FindBooksByKeyword(query);

            // Преобразуем каждый LegacyBook в новый объект Book
            List<BookEntity> books = [];
            foreach (var lb in legacyBooks)
            {
                // Создаём новый объект Book на основе данных из LegacyBook
                BookEntity book = new(lb.Title,
                                      lb.Code,
                                      1991,
                                      lb.AuthorName,
                                      "unknown",
                                      "unknown",
                                      "unknown");
                books.Add(book);
            }

            return books;
        }
    }
}