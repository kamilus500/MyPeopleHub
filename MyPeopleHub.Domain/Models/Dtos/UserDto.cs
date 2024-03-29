﻿namespace MyPeopleHub.Domain.Models.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string FullName { get; set; }
        public List<string> FriendIds { get; set; }
        public int CountOfFriends { get; set; }
    }
}
