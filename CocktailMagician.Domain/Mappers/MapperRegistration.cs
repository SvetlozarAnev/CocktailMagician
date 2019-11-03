﻿using CocktailMagician.Contracts.Objects;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CocktailMagician.Domain.Mappers
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<BarEntity, Bar>, BarMapper>();
            services.AddSingleton<IMapper<CocktailEntity, Cocktail>, CocktailMapper>();
            services.AddSingleton<IMapper<BarReviewEntity, BarReview>, BarReviewMapper>();
            services.AddSingleton<IMapper<CocktailReviewEntity, CocktailReview>, CocktailReviewMapper>();

            return services;
        }
    }
}
