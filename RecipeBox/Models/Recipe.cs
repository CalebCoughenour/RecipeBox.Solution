using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.RecipeIngredients = new HashSet<RecipeIngredient>();
      this.CategoryRecipes = new HashSet<CategoryRecipe>();
    }
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Instruction { get; set; }
    public int CookTime { get; set; }
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get;}
    public virtual ICollection<CategoryRecipe> CategoryRecipes { get;}
    public virtual ApplicationUser User { get; set; }
    
  }
}