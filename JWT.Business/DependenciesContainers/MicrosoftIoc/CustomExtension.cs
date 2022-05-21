using FluentValidation;
using JWT.Business.Concrete;
using JWT.Business.Interfaces;
using JWT.Business.ValidationRules.FluentValidation;
using JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Dtos.ProductDtos;
using Microsoft.Extensions.DependencyInjection;

namespace JWT.Business.DependenciesContainers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();


            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            return services;
        }
    }
}
