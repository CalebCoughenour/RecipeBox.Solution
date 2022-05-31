using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IngredientsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index ()
    {
      List<Ingredient> model = _db.Ingredients.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Ingredient ingredient)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      ingredient.User = currentUser;
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisIngredient = _db.Ingredients
        .Include(ingredient => ingredient.RecipeIngredients)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    } 

    public ActionResult Edit(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient ingredient)
    {
      _db.Entry(ingredient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }


}