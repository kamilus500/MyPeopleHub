namespace MyPeopleHub.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string PasswordHashed { get; set; } = default!;
        public int CountOfFriends { get; set; } = 0;
        public byte[]? Image { get; set; } = default!;

        public IEnumerable<Friendship> Friendships { get; set; }
    }
}
