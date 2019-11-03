using CocktailMagician.Contracts.Mappers;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Mappers
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddViewMappers(this IServiceCollection services)
        {
            services.AddSingleton<IViewModelMapper<Bar, BarViewModel>, BarViewMapper >();
            services.AddSingleton<IViewModelMapper<Cocktail, CocktailViewModel>, CocktailViewMapper>();
            services.AddSingleton<IViewModelMapper<BarReview, BarReviewViewModel>, BarReviewViewMapper>();
            services.AddSingleton<IViewModelMapper<CocktailReview, CocktailReviewViewModel>, CocktailReviewViewMapper>();        
                       
            return services;
        }
    }
}
