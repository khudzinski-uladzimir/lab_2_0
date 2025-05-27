using lab_2_0.Composite;
using BookEntity = lab_2_0.Book.Book;


namespace lab_2_0.Demo
{
    internal class CompositeDemo
    {
        public static void RunDemo()
        {
            // Создаём категории
            var fiction = new BookCategory("Fiction");
            var spaceOpera = new BookCategory("Cosmo-opera");
            var cyberpunk = new BookCategory("Cyberpunk");

            // Добавляем подкатегории
            fiction.AddComponent(spaceOpera);
            fiction.AddComponent(cyberpunk);

            // Добавляем книги
            fiction.AddComponent(new BookEntity("Book 3", "1234567890", 2020, "Author A", "Publisher A", "Genre A", "Description A"));
            spaceOpera.AddComponent(new BookEntity("Book 1", "1234567890", 2020, "Author A", "Publisher A", "Genre A", "Description A"));
            cyberpunk.AddComponent(new BookEntity("Book 2", "0987654321", 2021, "Author B", "Publisher B", "Genre B", "Description B"));

            fiction.Display();
        }
    }
}
