using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebServices.Models;

namespace WebServices.Controllers{

    public class MarksController : Controller{

        private IRepository repository;
        public MarksController(IRepository repo) {
            repository = repo;
        }

        public ActionResult Index() {
            return View(repository.arrivals);
        }

        [HttpPost]
        public string ReserveMarksRequest(){

            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            ReserveMarksRequest inputRequest = null;
            Stopwatch sw = Stopwatch.StartNew();
            try {
                inputRequest = JsonConvert.DeserializeObject<ReserveMarksRequest>(json);

                //request to base
                string location = inputRequest.Location;
                string document = inputRequest.Document;
                IEnumerable<string> artikuls = from material in inputRequest.Materials
                                             select material.Artikul;
                IEnumerable<string> batches = from material in inputRequest.Materials
                                                select material.Batch;

                Arrival currentDoc = repository.GetMarks(location, document, artikuls, batches, inputRequest);
                if (currentDoc == null) {
                    return null;
                }
                else{
                    currentDoc.Result = "Ok" ;
                    return JsonConvert.SerializeObject(currentDoc);
                }

            }
            catch(Exception e){
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                string error = e.Message;
                return "{\"Result\":\"Error\"}"; 
            }
        }

        [HttpPost]
        public string Arrival() {
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            Arrival inputRequest = null;
            Stopwatch sw = Stopwatch.StartNew();
            try {
                JavaScriptSerializer ser = new JavaScriptSerializer() { MaxJsonLength = Int32.MaxValue };
                inputRequest = ser.Deserialize<Arrival>(json);
                inputRequest.Date = DateTime.Now;
                inputRequest.Result = "ok";
                repository.AddMarks(inputRequest);

                Debug.WriteLine($"Query Time: {sw.ElapsedMilliseconds} ms");

                return "{\"Result\":\"Ok\"}";
            }catch(Exception e){
                string error = e.Message;
                return "{\"Result\":\"Error\"}"; 
            }
        }
    }
}