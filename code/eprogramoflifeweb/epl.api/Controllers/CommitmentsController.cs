using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using epl.core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class CommitmentsController : BaseController
  {
    public IActionResult Index()
    {
      var commitments = new List<Commitment>();
      commitments.Add(new DailyCommitment("mornigoffering"));
      commitments.Add(new DailyCommitment("nightprayers"));
      commitments.Add(new DailyCommitment("dailymeditation"));
      commitments.Add(new DailyCommitment("rosary"));
      commitments.Add(new DailyCommitment("visityeucharist"));
      commitments.Add(new DailyCommitment("angelus"));
      commitments.Add(new WeeklyCommitment("eucharistichour"));
      commitments.Add(new MonthlyCommitment("reconciliation"));
      commitments.Add(new MonthlyCommitment("reflection"));
      commitments.Add(new YearlyCommitment("triduum"));

      return Json(commitments);
    }

    [HttpPost]
    public IActionResult Add()
    {
      return Json(null);
    }
  }
}