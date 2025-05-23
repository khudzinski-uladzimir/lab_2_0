namespace lab_2_0
{
    public class User
    {
        public string Id { get; }
        public string Name { get; }

        // Add a private field to store users
        private List<User> _users = new List<User>();

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public static List<User> GetAllUsers()
        {
            _users.Add(new User("1", "Alice"));
            _users.Add(new User("2", "Bob"));
            return _users;
        }

        public User GetUserById(string userId)
        {
            foreach (var u in _users)
            {
                if (u.Id == userId)
                {
                    return u;
                }
            }
            return null;
        }
    }
}
