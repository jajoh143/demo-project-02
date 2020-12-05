using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace demo_project_01_stream.Models.Monsters
{
    public class DetailPageViewModel
    {
       public Monster Monster { get; set; }

       public DetailPageViewModel() 
       {
          
       }

       public async Task GetMonster(string url) 
       {
            using (HttpClient http = new HttpClient())
           {
               try
               {
                    var jsonMonsterDetail = await http.GetAsync("https://www.dnd5eapi.co" + url);
                    Monster =  JsonConvert.DeserializeObject<Monster>(await jsonMonsterDetail.Content.ReadAsStringAsync());
               }
               catch(Exception e)
               {
                   throw e;
               }
              
           }
       }
    }
}