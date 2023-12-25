using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyPeopleHub.Application.Account.Commands.AccountRegister;
using MyPeopleHub.Application.Mappings;
using System.Reflection;

namespace MyPeopleHub.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserMappingProfile>();
            });

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountRegisterCommand>());

            services.AddValidatorsFromAssemblyContaining<AccountRegisterCommandValidator>()
               .AddFluentValidationAutoValidation()
               .AddFluentValidationClientsideAdapters();
        }
    }
}