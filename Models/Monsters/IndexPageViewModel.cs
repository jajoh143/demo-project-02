using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace demo_project_01_stream.Models.Monsters
{
    public class IndexPageViewModel
    {
       public MonsterList MonsterList { get; set; }

       public IndexPageViewModel() 
       {
          
       }

       public async Task GetMonsterList() 
       {
            using (HttpClient http = new HttpClient())
           {
               try
               {
                    var jsonMonsters = await http.GetAsync("https://www.dnd5eapi.co/api/monsters");
                    MonsterList = JsonConvert.DeserializeObject<MonsterList>(await jsonMonsters.Content.ReadAsStringAsync());
               }
               catch(Exception e)
               {
                   throw e;
               }
              
           }
       }
    }
}