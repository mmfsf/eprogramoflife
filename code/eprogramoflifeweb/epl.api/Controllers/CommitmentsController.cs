using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using epl.api.Models;
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
            Repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<CommitmentModel>();
            var list = this.Repository.List();

            foreach (var item in list)
            {
                result.Add(new CommitmentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Frequency = item.Frequency,
                    Pointed = item.GetPoint(DateTime.Now) == Level.Done ? true : false
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Point([FromBody] dynamic point)
        {
            string id = point.id;
            bool done = point.done;

            var item = Repository.Get(id);
            item.Point(DateTime.Now, done ? Level.Done : Level.NotDone);
            this.Repository.Update(item);
            return Ok(item);
        }
    }
}