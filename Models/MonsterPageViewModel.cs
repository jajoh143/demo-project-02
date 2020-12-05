using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace demo_project_01_stream.Models
{
    public class MonsterPageViewModel
    {
       public Monster Monster { get; set; }

       public MonsterPageViewModel() 
       {
          
       }

       public async Task<Monster> getMonster() 
       {
            using (HttpClient http = new HttpClient())
           {
               try
               {
                    var jsonMonsters = await http.GetAsync("https://www.dnd5eapi.co/api/monsters");
                    MonsterList monsterList = JsonConvert.DeserializeObject<MonsterList>(await jsonMonsters.Content.ReadAsStringAsync());
                    string randMonsterApiEndpoint = monsterList.getMonsterApiEndpoint();
                    var jsonMonsterDetail = await http.GetAsync("https://www.dnd5eapi.co" + randMonsterApiEndpoint);
                    return JsonConvert.DeserializeObject<Monster>(await jsonMonsterDetail.Content.ReadAsStringAsync());
               }
               catch(Exception e)
               {
                   throw e;
               }
           }
       }
    }
}