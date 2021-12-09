using epl.core.ValuesObjects;

namespace epl.api.Models
{
    public class CommitmentModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Frequency Frequency { get; set; }
    public bool Pointed { get; set; }
  }
}
