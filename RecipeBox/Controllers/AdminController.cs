using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RecipeBox.Models;
using System.Threading.Tasks;
using RecipeBox.ViewModels;
using System.Linq;


namespace RecipeBox.Controllers
{
  
  public class AdminController : Controller
  {
    private readonly RoleManager<IdentityRole> _roleManager;
  
    public AdminController(RoleManager<IdentityRole> roleManager)
    {
      this._roleManager = roleManager;
    }

    public ActionResult CreateRole()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> CreateRole(CreateRoleViewModel model)
    {
      if(ModelState.IsValid)
      {
          IdentityRole identityRole = new IdentityRole { Name = model.RoleName};
          IdentityResult result = await _roleManager.CreateAsync(identityRole);
          if(result.Succeeded)
          {
            return RedirectToAction("ListRoles");
          }
          foreach(IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
      }

      return View(model);
    }

    public ActionResult ListRoles()
    {
      var roles = _roleManager.Roles;
      return View(roles);
    }

  }
}