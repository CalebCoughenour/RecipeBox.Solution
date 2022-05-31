using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class Category
  {
    public Category()
    {
      this.CategoryRecipes = new HashSet<CategoryRecipe>();
    }
    public int CategoryId { get; set;}
    public string Name { get; set; }
    public virtual ICollection<CategoryRecipe> CategoryRecipes { get;}
    public virtual ApplicationUser User { get; set; }
  }
}