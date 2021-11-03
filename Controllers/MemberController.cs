using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prj1.Models;
using System.Web.Security;
using PagedList;

namespace prj1.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        Entities db = new Entities();
        // GET: Member
        int pageSize = 5; //設定一頁顯示5筆資料
        public ActionResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var pokemons = db.Tablepokemons1081640 //把所有寶可夢放進pokemons建立List
                .OrderBy(m => m.pId).ToList();
            var result = pokemons.ToPagedList(currentPage, pageSize);
            return View("../Home/Index", "_LayoutMember", result); //使用_LayoutMember頁面
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();   // 登出
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tablepokemons1081640 pokemon)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.Tablepokemons1081640.Where(m => m.pId == pokemon.pId)
                    .FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(pokemon);
                }
                db.Tablepokemons1081640.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        public ActionResult Edit(string pId)
        {
            var employee = db.Tablepokemons1081640
                .Where(m => m.pId == pId).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Tablepokemons1081640 pokemon)
        {
            if (ModelState.IsValid)
            {
                var temp = db.Tablepokemons1081640
                    .Where(m => m.pId == pokemon.pId)
                    .FirstOrDefault();
                temp.pName = pokemon.pName;
                temp.pType = pokemon.pType;
                temp.pLv = pokemon.pLv;
                temp.pHp = pokemon.pHp;
                temp.pAtk = pokemon.pAtk;
                temp.pDef = pokemon.pDef;
                temp.pSpeed = pokemon.pSpeed;
                temp.pMoves = pokemon.pMoves;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        public ActionResult Delete(string pId)
        {
            var pokemon = db.Tablepokemons1081640
                .Where(m => m.pId == pId).FirstOrDefault();
            db.Tablepokemons1081640.Remove(pokemon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}