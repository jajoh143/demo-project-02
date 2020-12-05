using System.Collections.Generic;

namespace demo_project_01_stream.Models.Data
{
    public class Alignment
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Monster> Monsters { get; set; }
    }
}