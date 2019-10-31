using CockctailMagician.Contracts;
using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<BarEntity, Bar>, BarMapper>();
            services.AddSingleton<IMapper<CocktailEntity, Cocktail>, CocktailMapper>();

            return services;
        }
    }
}
