namespace CocktailMagician.Data.Models
{
    public class CocktailIngredientEntity
    {
        public int CocktailEntityId { get; set; }
        public int IngredientEntityId { get; set; }
        public CocktailEntity CocktailEntity { get; set; }
        public IngredientEntity IngredientEntity { get; set; }
    }
}
