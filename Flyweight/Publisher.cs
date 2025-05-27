namespace lab_2_0.Flyweight
{
    public class Publisher
    {
        // Это внутреннее состояние - общее для всех книг издательства
        public string Name { get; private set; }
        public string City { get; private set; }

        public Publisher(string name, string city)
        {
            Name = name;
            City = city;
        }

        // Этот метод принимает внешнее состояние (название книги и год)
        public void ShowInfo(string bookTitle, int year)
        {
            Console.WriteLine($"Publisher: {Name} ({City}) published '{bookTitle}' in {year}");
        }
    }

    // Фабрика для создания и хранения издательств
    public class PublisherFactory
    {
        // Словарь для хранения уже созданных издательств
        private static Dictionary<string, Publisher> publishers = new Dictionary<string, Publisher>();

        public static Publisher GetPublisher(string name, string city)
        {
            // Проверяем, существует ли паблишер
            if (publishers.ContainsKey(name))
            {
                //Console.WriteLine($"Using existing publisher: {name}");
                return publishers[name];
            }
            else
            {
                // Создаем нового паблишера если его еще нет
                //Console.WriteLine($"Creating new publisher: {name}");
                Publisher newPublisher = new Publisher(name, city);
                publishers[name] = newPublisher;
                return newPublisher;
            }
        }

        // Метод для подсчета созданных издательств
        public static int GetPublishersCount()
        {
            return publishers.Count;
        }


        // Метод для очистки списка созданных авторов
        public static void ClearPublishers()
        {
            publishers.Clear();
        }
    }
}
