using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pierre.Controllers
{
  public class FlavorTreatController : Controller
  {
    private readonly PierreContext _db;

    public FlavorTreatController(PierreContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Flavors and Treats";
      List<FlavorTreat> model = _db.FlavorTreat.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(FlavorTreat flavortreat)
    {
      if (_db.FlavorTreat.FirstOrDefault(
              tr => tr.TreatId == flavortreat.TreatId && 
                    tr.FlavorId == flavortreat.FlavorId) == null)
      {
        _db.FlavorTreat.Add(flavortreat);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}

