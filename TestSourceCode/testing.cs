using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using StackOverflow.Data;
using StackOverflow.Domain.Entities;
using StackOverflow.Web.Controllers;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Controllers
{
    public class QuestionController : Controller
    {
         private readonly IMappingEngine _mappingEngine;
        public QuestionController(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }
        
        public ActionResult Index(string order,int cant=25)
        {
            ViewData["cant"] = cant;

            List<QuestionListModel>models =new List<QuestionListModel>();
            var context = new StackOverflowContext();
            foreach (var q in context.Questions)
            {
              
                QuestionListModel question = new QuestionListModel();
                question.Title = q.Title;
                question.OwnerID = q.Owner.Id;
                question.OwnerName = q.Owner.Name+" "+q.Owner.LastName;
                question.CreationDate = q.CreationDate;
                question.Votes = q.Votes;
                question.Views = q.Views;
                question.Answers = q.Answers;
                question.QuestionID = q.Id;
                question.ImageUrl = context.Accounts.Find(q.Owner.Id).ImageUrl;
                models.Add(question);

            }
          
            models = models.OrderByDescending(x => x.CreationDate).ToList();
            if (cant > models.Count)
            {
                ViewBag.botton = "Hide";
            }
            models = models.Take(cant).ToList();
            ViewBag.filter = "Date";
            if (order != null)
            {
                if (order.Equals("Date"))
                {
                    models = models.OrderByDescending(x => x.CreationDate).ToList();
                    ViewBag.filter = "Date";
                }
                if (order.Equals("Vote"))
                {
                    models = models.OrderByDescending(x => x.Votes).ToList();
                    ViewBag.filter = "Vote";
                }
                if (order.Equals("View"))
                {
                    ViewBag.filter = "View";
                    models = models.OrderByDescending(x => x.Views).ToList();
                }
                if (order.Equals("Answer"))
                {
                    ViewBag.filter = "Answer";
                    models = models.OrderByDescending(x => x.Answers).ToList();
                }



            } 
          
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName]; 
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                Guid ownerId = Guid.Parse(ticket.Name);
                ViewData["loginUser"] = ownerId; 
            }
           
 
            return View(models);
        }
        [Authorize]
        public ActionResult NewQuestion()
        {
            return View(new NewQuestionModel());
        }

        [HttpPost]
        public ActionResult NewQuestion(NewQuestionModel model)
        {
            if (ModelState.IsValid)
            {
                var question = _mappingEngine.Map<NewQuestionModel,Question>(model);
                var context = new StackOverflowContext();
                 HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if(cookie!=null)
                {
                     FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                     Guid ownerId = Guid.Parse(ticket.Name);
                     question.CreationDate = DateTime.Now;
                     question.ModififcationnDate = DateTime.Now;
                     question.Votes = 0;
                     question.Views = 0;
                     question.Answers = 0;
                     question.Owner = context.Accounts.FirstOrDefault(x=>x.Id==ownerId);
                     context.Questions.Add(question);        
                     context.SaveChanges();
                }
              
               return RedirectToAction("Index");            
                
            }
            return View(model);

       
        }
        [AllowAnonymous]
        public ActionResult QuestionDetail( Guid ID)
        {
            ViewData["id"] = ID.ToString();
            TempData["qID"] = ID;
            if (TempData["AnswerBelow5word"] != null)
                ViewData["AnswerBelow5word"] = TempData["AnswerBelow5word"];
            
            addQuestionViews(ID);
            QuestionDetailModel model = new QuestionDetailModel();
            if (ModelState.IsValid)
            {
                var context = new StackOverflowContext();
                HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    Guid ownerId = Guid.Parse(ticket.Name);
                    ViewData["logUser"] = ownerId;
                    foreach (var v in context.Votes)
                    {
                        if (v.AccountID == ownerId && v.FatherID == ID)
                            ViewBag.Voted = "You alredy voted for this Question";
                    }
                }
                var md = new MarkdownDeep.Markdown();
                model.Title = context.Questions.FirstOrDefault(x => x.Id == ID).Title;
                model.Decription = md.Transform(context.Questions.FirstOrDefault(x => x.Id == ID).Description);
                model.QuestionId = ID;
                model.Owner = context.Questions.FirstOrDefault(x => x.Id == ID).Owner;
                model.Votes = context.Questions.FirstOrDefault(x => x.Id == ID).Votes;
                model.Views = context.Questions.FirstOrDefault(x => x.Id == ID).Views;
                int cont = Enumerable.Count(context.Answers, a => a.QuestionId == ID);
                context.Questions.Find(ID).Answers=cont;
                context.SaveChanges();
                model.Answers = context.Questions.FirstOrDefault(x => x.Id == ID).Answers;
                return View(model);

            }
            
            return View(model);
        }

        [Authorize]
        public ActionResult UpVote(Guid ID)
        {
            var context = new StackOverflowContext();
            var question = context.Questions.Find(ID);
            var votes = context.Votes;
            var vote = new Vote();
             HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                Guid ownerID = Guid.Parse(ticket.Name);

                foreach (var v in votes)
                {
                    if(v.AccountID==ownerID&&v.FatherID==ID)
                        return RedirectToAction("QuestionDetail", new { ID = ID });
                }
                vote.AccountID = ownerID;
                vote.FatherID = ID;
                votes.Add(vote);
                question.Votes++;
            }

            context.SaveChanges();
            return RedirectToAction("QuestionDetail", new { ID = ID });
           
        }

        [Authorize]
        public ActionResult DownVote(Guid ID)
        {
            var context = new StackOverflowContext();
            var question = context.Questions.Find(ID);
            var votes = context.Votes;
            var vote = new Vote();
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                Guid ownerID = Guid.Parse(ticket.Name);

                foreach (var v in votes)
                {
                    if (v.AccountID == ownerID && v.FatherID == ID)
                        return RedirectToAction("QuestionDetail", new { ID = ID });
                }
                vote.AccountID = ownerID;
                vote.FatherID = ID;
                votes.Add(vote);
                question.Votes--;
            }

            context.SaveChanges();
            return RedirectToAction("QuestionDetail", new { ID = ID });
        }

        [Authorize]
        public ActionResult DeleteQuestion(Guid ID)
        {
            var context = new StackOverflowContext();
            var question = context.Questions.Find(ID);
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                Guid ownerId = Guid.Parse(ticket.Name);
                if (question.Owner.Id == ownerId)
                {
                    foreach (Answer a in context.Answers)
                    {
                        if (a.QuestionId == ID)
                        {
                            context.Answers.Remove(a);
                        } 
                    }
                    foreach (Comment c in context.Comments)
                    {
                        if (c.FatherId == ID)
                        {
                            context.Comments.Remove(c);
                        }
                    }
                    context.Questions.Remove(question);

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                

            }

            return RedirectToAction("QuestionDetail", new { ID = ID });

        }

        private void addQuestionViews(Guid qId)
        {
            var context = new StackOverflowContext();
            context.Questions.Find(qId).Views++;
            context.SaveChanges();         
        }

        public ActionResult OrerByDate()
        {
            return RedirectToAction("Index",new{order="Date"});
        }
        public ActionResult OrerByVotes()
        {
            return RedirectToAction("Index", new { order = "Vote" });
        }
        public ActionResult OrerByAnswers()
        {
            return RedirectToAction("Index", new { order = "Answer" });
        }
        public ActionResult OrerByViews()
        {
            return RedirectToAction("Index", new { order = "View" });
        }


     
    }
}