using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demo_project_01_stream.Models;
using demo_project_01_stream.Models.Monsters;
using Microsoft.EntityFrameworkCore;
using demo_project_01_stream.Models.Data;

namespace demo_project_01_stream.Controllers
{
    public class MonstersController : Controller
    {
        private readonly ILogger<MonstersController> _logger;
        private MonsterDataContext _monsterDataContext;


        public MonstersController(ILogger<MonstersController> logger, MonsterDataContext monsterDataContext)
        {
            _logger = logger;
            _monsterDataContext = monsterDataContext;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexPageViewModel();
            await vm.GetMonsterList();
            return View(vm);
        }

        public async Task<IActionResult> Detail(string url) 
        {
            var vm = new DetailPageViewModel();
            await vm.GetMonster(url);
            return View(vm);
        }

        public async Task<IActionResult> Monster()
        {
            MonsterPageViewModel vm = new MonsterPageViewModel();
            vm.Monster = await vm.getMonster();
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveMonster([FromForm]Models.Monster monster)
        {
            List<Alignment> alignments = _monsterDataContext.Alignments.ToList();
            Models.Data.Monster dataMonster = new Models.Data.Monster()
            {
                Name = monster.Name,
                Type = monster.Type,
                Size = monster.Size,
                Subtype = string.IsNullOrWhiteSpace(monster.Subtype) ? monster.Subtype : "",
                Alignment = alignments.Single(li => li.Name.ToLower() == monster.Alignment),
                HitPoints = monster.HitPoints
            };

            _monsterDataContext.Monsters.Add(dataMonster);
            _monsterDataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
