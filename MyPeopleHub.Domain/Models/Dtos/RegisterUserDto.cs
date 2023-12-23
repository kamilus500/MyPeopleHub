﻿namespace MyPeopleHub.Domain.Models.Dtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
