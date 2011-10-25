using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atos.Web.Mobile.Trends.Models;

namespace Atos.Web.Mobile.Trends.Controllers
{   
    public class UsersController : Controller
    {
        private AtosWebMobileTrendsContext context = new AtosWebMobileTrendsContext();

        //
        // GET: /Users/

        public ViewResult Index()
        {
            return View(context.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ViewResult Details(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            ViewBag.PossibleAnswers = context.Answers;
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleAnswers = context.Answers;
            return View(user);
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            ViewBag.PossibleAnswers = context.Answers;
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleAnswers = context.Answers;
            return View(user);
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SaveUser(int userId, string region, string browser, string browserVersion, string platform, int answerId)
        {
            string clientIP = HttpContext.Request.UserHostAddress.ToString();
             User user;

            if (userId > 0)
                user = context.Users.Single(u => u.Id == userId);
            else
                user = new User();

            if (userId > 0)
                user.Id = userId;
            
            if (!String.IsNullOrEmpty(region))
                user.Region = region;
            
            if (!String.IsNullOrEmpty(browser))
                user.Browser = browser;
            
            if (!String.IsNullOrEmpty(browserVersion))
                user.BrowserVersion = browserVersion;
            
            if (!String.IsNullOrEmpty(platform))
                user.Platform = platform;
            
            if (!String.IsNullOrEmpty(clientIP))
                user.IPAddress = clientIP;
            
            if (answerId > 0)
                user.AnswerId = answerId;
            
            if (userId > 0)
                context.Entry(user).State = EntityState.Modified;
            else
                context.Users.Add(user);

            user.Id = context.SaveChanges();

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = user };
        }
    }
}