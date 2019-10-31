using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers.Contracts
{
    public interface IMapper<TEntity, TObject>
    {
        TObject MapFrom(TEntity entity);
    }
}
