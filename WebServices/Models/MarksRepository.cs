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

            var selectedDoc = (from arrival in arrivals
                              join material in materials on arrival.Id equals material.ArrivalId
                              where arrival.Location == location && arrival.Document == document && artikuls.Contains(material.Artikul) && batches.Contains(material.Batch)
                              select new Arrival{
                                  Location = arrival.Location,
                                  Document = arrival.Document,
                                  Status = arrival.Status,
                                  Materials = arrival.Materials,
                                  Date = arrival.Date, 
                                  Id=arrival.Id
                              }).FirstOrDefault();

            return (Arrival)selectedDoc;
            
        }

        public void AddMarks(Arrival arrival){
            context.Arrival.Add(arrival);
            context.SaveChanges();
        }
    }
}