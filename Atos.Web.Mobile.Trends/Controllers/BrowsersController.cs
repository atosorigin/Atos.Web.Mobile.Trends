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
    public class BrowsersController : Controller
    {
        private AtosWebMobileTrendsContext context = new AtosWebMobileTrendsContext();

        //
        // GET: /Browsers/

        public ViewResult Index()
        {
            return View(context.Browsers.ToList());
        }

        //
        // GET: /Browsers/Details/5

        public ViewResult Details(int id)
        {
            Browser browser = context.Browsers.Single(x => x.Id == id);
            return View(browser);
        }

        //
        // GET: /Browsers/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Browsers/Create

        [HttpPost]
        public ActionResult Create(Browser browser)
        {
            if (ModelState.IsValid)
            {
                context.Browsers.Add(browser);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(browser);
        }
        
        //
        // GET: /Browsers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Browser browser = context.Browsers.Single(x => x.Id == id);
            return View(browser);
        }

        //
        // POST: /Browsers/Edit/5

        [HttpPost]
        public ActionResult Edit(Browser browser)
        {
            if (ModelState.IsValid)
            {
                context.Entry(browser).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(browser);
        }

        //
        // GET: /Browsers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Browser browser = context.Browsers.Single(x => x.Id == id);
            return View(browser);
        }

        //
        // POST: /Browsers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Browser browser = context.Browsers.Single(x => x.Id == id);
            context.Browsers.Remove(browser);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool SaveBrowser(string browserName, string browserVersion, string browserPlatform, string clientIP)
        {
            Browser browser = new Browser();

            browser.Name = browserName;
            browser.Version = browserVersion;
            browser.Platform = browserPlatform;
            browser.ClientIP = clientIP;
            browser.TimeStamp = DateTime.Now;
            
            context.Browsers.Add(browser);
            context.SaveChanges();

            return true;
        }
    }
}