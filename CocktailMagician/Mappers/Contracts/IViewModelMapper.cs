using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Contracts.Mappers
{
    public interface IViewModelMapper<TObject, TViewModel>
    {
        TViewModel MapFrom(TObject entity);
    }
}
