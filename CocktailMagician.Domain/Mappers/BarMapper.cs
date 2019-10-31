using CockctailMagician.Contracts;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public class BarMapper : IMapper<BarEntity, Bar>
    {
        public Bar MapFrom(BarEntity entity)
        => new Bar
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            Rating = entity.Rating,
            IsHidden = entity.IsHidden,
            ImagePath = entity.ImagePath
        };
    }
}
