using FluentValidation;

namespace MyPeopleHub.Application.Friendship.Commands.CreateFrienship
{
    public class CreateFriendshipCommandValidator : AbstractValidator<CreateFrienshipCommand>
    {
        public CreateFriendshipCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User id is empty");

            RuleFor(x => x.FriendId)
                .NotEmpty().WithMessage("Friend id is empty");
        }
    }

}
