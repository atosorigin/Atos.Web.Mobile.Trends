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
    public class AnswersController : Controller
    {
        private AtosWebMobileTrendsContext context = new AtosWebMobileTrendsContext();

        //
        // GET: /Answers/

        public ViewResult Index()
        {
            return View(context.Answers.Include(answer => answer.Question).ToList());
        }

        //
        // GET: /Answers/Details/5

        public ViewResult Details(int id)
        {
            Answer answer = context.Answers.Single(x => x.Id == id);
            return View(answer);
        }

        //
        // GET: /Answers/Create

        public ActionResult Create()
        {
            ViewBag.PossibleQuestions = context.Questions;
            return View();
        } 

        //
        // POST: /Answers/Create

        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            if (ModelState.IsValid)
            {
                context.Answers.Add(answer);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleQuestions = context.Questions;
            return View(answer);
        }
        
        //
        // GET: /Answers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Answer answer = context.Answers.Single(x => x.Id == id);
            ViewBag.PossibleQuestions = context.Questions;
            return View(answer);
        }

        //
        // POST: /Answers/Edit/5

        [HttpPost]
        public ActionResult Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(answer).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleQuestions = context.Questions;
            return View(answer);
        }

        //
        // GET: /Answers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Answer answer = context.Answers.Single(x => x.Id == id);
            return View(answer);
        }

        //
        // POST: /Answers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = context.Answers.Single(x => x.Id == id);
            context.Answers.Remove(answer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SaveAnswer(string questionId, string answerId)
        {
            int id;

            if (!String.IsNullOrEmpty(answerId))
            {
                id = Convert.ToInt32(answerId);
                var answer = context.Answers.Single(x => x.Id == id);

                answer.NumberOfChosenAsAnswer++;

                context.Entry(answer).State = EntityState.Modified;
                context.SaveChanges();
                               
            }

            var answers = new Object();

            if (!String.IsNullOrEmpty(questionId))
            {
                id = Convert.ToInt32(questionId);
                
                
                answers = context.Answers.Where(q => q.QuestionId == id).OrderByDescending(q => q.NumberOfChosenAsAnswer).ToList();
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = answers }; 
        }

        public JsonResult GetAnswers(string questionId)
        {
            int id;

            var answers = new Object();

            if (!String.IsNullOrEmpty(questionId))
            {
                id = Convert.ToInt32(questionId);


                answers = context.Answers.Where(q => q.QuestionId == id).OrderByDescending(q => q.NumberOfChosenAsAnswer).ToList();
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = answers };
        }
    }
}