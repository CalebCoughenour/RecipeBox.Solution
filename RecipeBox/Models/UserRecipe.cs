using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class UserRecipe
  {
    public int UserRecipeId { get; set;}
    public int RecipeId {get; set;}
    public virtual Recipe Recipe {get; set;}
    public virtual ApplicationUser User { get; set; }
  }
}