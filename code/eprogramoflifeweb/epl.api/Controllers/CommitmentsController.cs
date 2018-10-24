using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using epl.core.Domain;
using epl.core.Interfaces;
using epl.core.ValuesObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class CommitmentsController : BaseController
  {
    private IRepository<Commitment> Repository { get; set; }

    public CommitmentsController(IRepository<Commitment> repository)
    {
      this.Repository = repository;
    }

    public IActionResult Index()
    {
      var list = this.Repository.List();
      return Json(list);
    }

    [HttpPost]
    public IActionResult Point([FromBody] dynamic point)
    {
      int id = point.id;
      bool done = point.done;

      var item = this.Repository.Get(id);
      item.Point(DateTime.Now, done ? Level.Done : Level.NotDone);
      this.Repository.Update(item);
      return Json(item);
    }
  }
}