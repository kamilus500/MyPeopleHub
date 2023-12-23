using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyPeopleHub.Application.Account.Commands.AccountRegister;
using System.Reflection;

namespace MyPeopleHub.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountRegisterCommand>());
        }
    }
}
