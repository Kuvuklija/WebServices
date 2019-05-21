using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices.Concrete;

namespace WebServices.Models{

    public class MarksRepository : IRepository{

        private EFContext context = new EFContext();

        public IEnumerable<Arrival> arrivals => context.Arrival.ToArray();
        public IEnumerable<Material> materials => context.Material.ToArray();
        public IEnumerable<Pallet> pallets => context.Pallet.ToArray();
        public IEnumerable<Carton> cartons => context.Carton.ToArray();
        public IEnumerable<Mark> marks => context.Mark.ToArray();

        public Arrival GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches, ReserveMarksRequest requestObject){

            //Arrival selectedDoc = context.Arrival
            //    .Where(t => t.Location == location && t.Document == document && artikuls.Contains(t.Materials) && batches.Contains(t.Batch)).FirstOrDefault();

            var selectedDoc = (from arrival in arrivals
                              join material in materials on arrival.Id equals material.ArrivalId
                              where arrival.Location == location && arrival.Document == document && artikuls.Contains(material.Artikul) && batches.Contains(material.Batch)
                              select new Arrival
                              {
                                  Location = arrival.Location,
                                  Document = arrival.Document,
                                  Status = arrival.Status,
                                  Materials = arrival.Materials,
                                  Date = arrival.Date, // have to bring from base
                                  Id=arrival.Id
                              }).FirstOrDefault();


            return (Arrival)selectedDoc;
                
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

        public void AddMarks(Arrival arrival){
            context.Arrival.Add(arrival);
            context.SaveChanges();
        }
    }
}