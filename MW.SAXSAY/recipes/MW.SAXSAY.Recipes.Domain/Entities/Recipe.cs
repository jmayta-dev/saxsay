using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public sealed class Recipe: IEntity<RecipeId>
{
    public RecipeId? Id { get; set; }
    public string Name { get; set; }
    public PreparationTime PreparationTime { get; set; }
    public int Portions { get; set; }
    public string ImageUrl { get; set; }
    public string Preparation { get; set; }
    public double Calories { get; set; }
    public string CommentsSuggestions { get; set; }
    public IEnumerable<DietaryRestriction>? DietaryRestrictions { get; set; }
    public IEnumerable<RawMaterial>? Ingredients { get; set; }
    public IEnumerable<NutritionalComponent>? NutritionalInformation { get; set; }

    public Recipe(
        RecipeId? id,
        string name,
        PreparationTime preparationTime,
        int portions,
        string imageUrl,
        string preparation,
        double calories,
        string commentsSuggestions,
        IEnumerable<DietaryRestriction>? dietaryRestrictions,
        IEnumerable<RawMaterial>? ingredients,
        IEnumerable<NutritionalComponent>? nutritionalInformation)
    {
        Id = id;
        Name = name;
        PreparationTime = preparationTime;
        Portions = portions;
        ImageUrl = imageUrl;
        Preparation = preparation;
        Calories = calories;
        CommentsSuggestions = commentsSuggestions;
        DietaryRestrictions = dietaryRestrictions;
        Ingredients = ingredients;
        NutritionalInformation = nutritionalInformation;
    }
}