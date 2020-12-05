using System;
using Newtonsoft.Json;

namespace demo_project_01_stream.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public string Size { get; set; }

        public string Type { get; set; }
        public string? Subtype { get; set; }
        public string Alignment { get; set; }
        [JsonProperty(PropertyName = "armor_class")]
        public int ArmorClass { get; set; }
        [JsonProperty(PropertyName = "hit_points")]
        public int HitPoints { get; set; }
    }
}