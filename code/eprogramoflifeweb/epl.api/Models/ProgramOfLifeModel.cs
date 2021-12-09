using System.Collections.Generic;

namespace epl.api.Models
{
    public class ProgramOfLifeModel
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Ideal { get; set; }
        public string Virtue { get; set; }
        public IList<string> Path { get; set; }
    }
}
