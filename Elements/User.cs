namespace lab_2_0.Elements
{
    public class User
    {
        public string Id { get; }
        public string Name { get; }

        private static readonly List<User> _users = [];

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<User> GetAllUsers()
        {
            return _users;
        }

        public static void AddUser(User user)
        {
            if (!_users.Exists(u => u.Id == user.Id))
                _users.Add(user);
        }

        public static bool RemoveUser(string id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return true;
            }
            return false;
        }

        public static User? FindUserById(string id)
        {
            return _users.Find(u => u.Id == id);
        }
    }
}
