using System.ComponentModel.DataAnnotations;

namespace RecipeBox.ViewModels
{
  public class CreateRoleViewModel
  {
    [Required]
    public string RoleName { get; set; }
  }
}