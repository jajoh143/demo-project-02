using System;
using Newtonsoft.Json;

namespace demo_project_01_stream.Models.Data
{
    public class Monster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public string Type { get; set; }
        public string Subtype { get; set; }
        public Alignment Alignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
    }
}