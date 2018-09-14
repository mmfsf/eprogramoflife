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
      this.FakeDataInit();
    }

    private void FakeDataInit()
    {
      var commitments = new List<Commitment>
      {
        new DailyCommitment("mornigoffering"),
        new DailyCommitment("nightprayers"),
        new DailyCommitment("dailymeditation"),
        new DailyCommitment("rosary"),
        new DailyCommitment("visityeucharist"),
        new DailyCommitment("angelus"),
        new WeeklyCommitment("eucharistichour"),
        new MonthlyCommitment("reconciliation"),
        new MonthlyCommitment("reflection"),
        new YearlyCommitment("triduum")
      };

      foreach (var item in commitments)
      {
        this.Repository.Add(item);
      }
    }

    public IActionResult Index()
    {
      return Json(this.Repository.List());
    }

    [HttpPost]
    public IActionResult Point()
    {
      var item = this.Repository.Get(1);
      item.Point(DateTime.Now, Level.Done);
      this.Repository.Update(item);
      return Json(item);
    }
  }
}