using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class UserEntity : IdentityUser
    {
        public IEnumerable<BarReviewEntity> BarReviews { get; set; }
        public IEnumerable<CocktailReviewEntity> CocktailReviews { get; set; }
    }
}
