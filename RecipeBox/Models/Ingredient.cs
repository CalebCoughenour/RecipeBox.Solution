using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.RecipeIngredients = new HashSet<RecipeIngredient>();
    }
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; }
    public virtual ApplicationUser User { get; set; }
  }
}