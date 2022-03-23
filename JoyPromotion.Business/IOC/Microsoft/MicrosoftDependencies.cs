using FluentValidation;
using JoyPromotion.Business.Abstract;
using JoyPromotion.Business.Concrete;
using JoyPromotion.Business.Mapping;
using JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.DataAccess.Concrete.Dapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Shared.DataAccess;
using JoyPromotion.Shared.DataAccess.Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace JoyPromotion.Business.IOC.Microsoft
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(connection => new SqlConnection(configuration.GetConnectionString("JoyPromotionLocal")));

            Cookie(services);

            Generic(services);

            Validator(services);

            Mapper(services);
        }


        private static void Cookie(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "JoyPromotion"; // Cookie'nin tarayıcıda gözükeceği adı
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict; // Diğer web sitelerin cookie kullanımını kapadık
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Bu cookie hem https de hem de http de çalışacak
                options.ExpireTimeSpan = TimeSpan.FromDays(20); // Kullanıcının ilgili bilgileri 20 gün boyunca hayatta kalıcak
                options.LoginPath = new PathString("/Auth/Login");
                options.LogoutPath = new PathString("/Auth/Logout");
                options.AccessDeniedPath = new PathString("/Auth/Logout");
                options.SlidingExpiration = true;
            });

            // services.AddSession();
            // services.AddDistributedMemoryCache();
        }

        private static void Generic(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(DpGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IContentRepository, DpContentRepository>();
            services.AddScoped<IContentService, ContentManager>();
            services.AddScoped<IUserRepository, DpUserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICategoryRepository, DpCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ITagRepository, DpTagRepository>();
            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<IContentTagRepository, DpContentTagRepository>();
            services.AddScoped<IContentTagService, ContentTagManager>();
            services.AddScoped<ISocialMediaRepository, DpSocialMediaRepository>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IUserSocialMediaRepository, DpUserSocialMediaRepository>();
            services.AddScoped<IUserSocialMediaService, UserSocialMediaManager>();
            services.AddScoped<IRoleRepository, DpRoleRepository>();
            services.AddScoped<IRoleService, RoleManager>();
        }

        private static void Validator(IServiceCollection services)
        {
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();
            services.AddTransient<IValidator<ContentAddDto>, ContentAddDtoValidator>();
            services.AddTransient<IValidator<ContentUpdateDto>, ContentUpdateDtoValidator>();
            services.AddTransient<IValidator<SocialMediaAddDto>, SocialMediaAddDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();
            services.AddTransient<IValidator<UserPasswordDto>, UserPasswordDtoValidator>();
        }

        private static void Mapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryProfile),
                       typeof(ContentProfile),
                       typeof(SocialMediaProfile),
                       typeof(TagProfile),
                       typeof(UserProfile),
                       typeof(RoleProfile));
        }
    }
}
