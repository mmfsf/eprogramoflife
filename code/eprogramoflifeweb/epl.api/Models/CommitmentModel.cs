using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epl.api.Models
{
  public class CommitmentModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Frequency Frequency { get; set; }
    public bool Pointed { get; set; }
  }
}
