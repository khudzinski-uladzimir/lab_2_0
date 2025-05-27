namespace lab_2_0.Flyweight
{
    public class Author
    {
        // Это внутреннее состояние - общее для всех книг автора
        public string Name { get; private set; }
        public string Country { get; private set; }

        public Author(string name, string country)
        {
            Name = name;
            Country = country;
        }

        // Этот метод принимает внешнее состояние (название книги)
        public void ShowInfo(string bookTitle)
        {
            Console.WriteLine($"Author: {Name} from {Country} wrote '{bookTitle}'");
        }
    }

    // Фабрика для создания и хранения авторов
    public class AuthorFactory
    {
        // Словарь для хранения уже созданных авторов
        private static Dictionary<string, Author> authors = new Dictionary<string, Author>();

        public static Author GetAuthor(string name, string country)
        {
            // Проверяем, есть ли уже такой автор
            if (authors.ContainsKey(name))
            {
                //Console.WriteLine($"Use existing author: {name}");
                return authors[name];
            }
            else
            {
                // Создаем нового автора только если его еще нет
                //Console.WriteLine($"Create a new author: {name}");
                Author newAuthor = new Author(name, country);
                authors[name] = newAuthor;
                return newAuthor;
            }
        }

        // Метод для подсчета созданных авторов
        public static int GetAuthorsCount()
        {
            return authors.Count;
        }

        // Метод для очистки списка созданных авторов
        public static void ClearAuthors()
        {
            authors.Clear();
        }
    }
}
