using System;
using System.Collections.Generic;

namespace demo_project_01_stream.Models
{
    public class MonsterList
    {
        public int Count { get; set; }
        public List<MonsterListResultDetail> Results { get; set; }

        public string getMonsterApiEndpoint()
        {
            Random rand = new Random();
            return Results[rand.Next(Count)].Url;
        }
    }

    public class MonsterListResultDetail
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}