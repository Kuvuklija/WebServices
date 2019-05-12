using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices.Controllers{

    public class HomeController : Controller{

        private IRepository repository;
        public HomeController(IRepository repo) {
            repository = repo;
        }

        //  ---MVC---
        //private ReservationRepository repo = ReservationRepository.Current;
    
        //public ActionResult Index(){
        //    return View(repo.GetAll());
        //}

        //public ActionResult Add(Reservation item) {
        //    if (ModelState.IsValid) {
        //        repo.Add(item);
        //        return RedirectToAction("Index");
        //    } else {
        //        return View("Index");
        //    }
        //}

        //public ActionResult Remove(int id) {
        //    repo.Remove(id);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Update(Reservation item) {
        //    if(ModelState.IsValid && repo.Update(item)) {
        //        return RedirectToAction("Index");
        //    } else {
        //        return View("Index");
        //    }
        //}

        public ViewResult Index() {
            return View(); //only html-markup, model is used by API controller
        }

        [HttpPost]
        public JsonResult ReserveMarksRequest(){

            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            ReserveMarksRequest input = null;
            try {
                input = JsonConvert.DeserializeObject<ReserveMarksRequest>(json);
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //input = ser.Deserialize<ReserveMarksRequest>(json);
                input.Status = "Reserved";

                //request to base
                string location = input.Location;
                string document = input.Document;
                IEnumerable<string> artikuls = from material in input.Materials
                                             select material.Artikul;
                IEnumerable<string> batches = from material in input.Materials
                                                select material.Batch;

                string jsonStr = repository.GetMarks(location, document, artikuls, batches);
            }
            catch(Exception e){
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                string error = e.Message;
                return Json(new { Status = "BAD", Data = "" }, JsonRequestBehavior.AllowGet);
            }

            return new JsonResult();
        }
    }
}