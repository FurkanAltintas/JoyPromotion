using FluentValidation;
using JoyPromotion.Business.Abstract;
using JoyPromotion.Business.Concrete;
using JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Shared.DataAccess;
using JoyPromotion.Shared.DataAccess.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace JoyPromotion.Business.IOC.Microsoft
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(connection => new SqlConnection(configuration.GetConnectionString("JoyPromotionLocal")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(DpGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IContentService, ContentManager>();

            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();
            services.AddTransient<IValidator<ContentAddDto>, ContentAddDtoValidator>();
            services.AddTransient<IValidator<ContentUpdateDto>, ContentUpdateDtoValidator>();
            services.AddTransient<IValidator<SocialMediaAddDto>, SocialMediaAddDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();
        }
    }
}
