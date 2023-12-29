namespace MyPeopleHub.Domain.Models.Dtos
{
    public record LoginResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
