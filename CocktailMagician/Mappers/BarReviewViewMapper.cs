using CocktailMagician.Contracts.Mappers;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Mappers
{   
        public class BarReviewViewMapper : IViewModelMapper<BarReview, BarReviewViewModel>
        {
            public BarReviewViewModel MapFrom(BarReview entity)
    =>
        new BarReviewViewModel()
        {
            Id = entity.Id,
            UserEntityId = entity.UserEntityId,
            BarEntityId = entity.BarEntityId,
            Rating = entity.Rating,
            Review = entity.Review
        };
        }
    
}


