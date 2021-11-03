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
    public class HomeController : Controller
    {
        Entities db = new Entities();
        int pageSize = 5; //設定一頁顯示5筆資料
        // GET: Home
        public ActionResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page; //若page小於1則顯示第一頁
            var pokemons = db.Tablepokemons1081640.ToList();
            var result = pokemons.ToPagedList(currentPage, pageSize);
            return View(result);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string fUserId, string fPwd)
        {

            var member = db.TableMembers1081640 //把註冊好的帳密做比對
                .Where(m => m.fUserId == fUserId && m.fPwd == fPwd)
                .FirstOrDefault();

            if (member == null) //未註冊狀況
            {
                ViewBag.Message = "帳號或密碼錯誤";
                return View();
            }

            Session["Welcome"] = member.fName + "歡迎光臨"; //顯示登入成功的訊息
            FormsAuthentication.RedirectFromLoginPage(fUserId, true);
            return RedirectToAction("Index", "Member");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(TableMembers1081640 aMember)
        {
            if (ModelState.IsValid == false) //沒有通過驗證直接顯示目前頁面
            {
                return View();
            }

            var member = db.TableMembers1081640 //取得已註冊的會員帳號
                .Where(m => m.fUserId == aMember.fUserId)
                .FirstOrDefault();

            if (member == null) //還未註冊狀況
            {
                db.TableMembers1081640.Add(aMember); //新增會員
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Message = "帳號重複，註冊失敗";
            return View();
        }





        

        
    }
}
