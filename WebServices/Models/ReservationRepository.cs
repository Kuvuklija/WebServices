using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Concrete;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebServices.Models
{
    public class ReservationRepository{

        private EFContext context=new EFContext();

        public IEnumerable<HeadReserve> headReserves=>context.HeadReserve;
        public IEnumerable<BoxesReserve> boxesReserves=>context.BoxesReserve;
        public IEnumerable<MarksReserve> marksReserves=>context.MarksReserve;

        public HeadReserve GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches, ReserveMarksRequest requestObject){

            //var selectedHeads = from t in headReserves 
            //                   where t.Location==location && t.Document==document && artikuls.Contains(t.Artikul) && batches.Contains(t.Batch)
            //                   group t by t.DocumentRow into g
            //                   select g; 

            HeadReserve selectedDoc = headReserves
                .Where(t => t.Location == location && t.Document == document && artikuls.Contains(t.Artikul) && batches.Contains(t.Batch)).FirstOrDefault();

            //HeadReserve selectedDoc = (HeadReserve)headReserves
            //    .Where(t=>requestObject.Materials.Select(p => p.Artikul).Contains(t.Artikul));

            return selectedDoc;
                
            //JavaScriptSerializer ser = new JavaScriptSerializer();

            //foreach (var s in selectedHeads){ //very bad!!!!!!!!!!!
            //    foreach(HeadReserve headReserve in s) {
            //        var json=ser.Serialize(headReserve);
            //    }
            //        //header
            //        Func<HeadReserve, JObject> objToJson1 =
            //            o => new JObject(
            //                new JProperty("Location", o.Location),
            //                new JProperty("Document", o.Document),
            //                new JProperty("Result", "Ok"),
            //                new JProperty("Artikul", o.Artikul),
            //                new JProperty("Batch", o.Batch),
            //                new JProperty("DocumentRow", o.DocumentRow));
            //        header += new JArray(s.Select(objToJson1)).ToString();
            //    }
        }

        public void AddMarks(HeadReserve headReserve, BoxesReserve boxesReserve, MarksReserve marksReserve ){
           //TODO
        }

        private static ReservationRepository repo = new ReservationRepository();

        public static ReservationRepository Current{get{return repo;}}

        private List<Reservation> data = new List<Reservation> {
            new Reservation { ReservationId = 1, ClientName = "Adam", Location = "Board Room"},
            new Reservation {ReservationId = 2, ClientName = "Jacqui", Location = "Lecture Hall"},
            new Reservation {ReservationId = 3, ClientName = "Russell", Location = "Meeting Room 1"},
        };

        //CRUD
        public IEnumerable<Reservation> GetAll(){
            return data;
        }

        public Reservation Get(int id){
            return data.Where(r => r.ReservationId == id).FirstOrDefault();
        }

        

        public Reservation Add(Reservation item){
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id){
            Reservation item = Get(id);
            if (item != null){
                data.Remove(item);
            }
        }

        public bool Update(Reservation item){
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null){ //TODO
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            } else{
                return false;
            }
        }
    }
}
