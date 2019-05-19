using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices.Concrete;

namespace WebServices.Models{

    public class MarksRepository : IRepository{

        private EFContext context = new EFContext();

        public IEnumerable<HeadReserve> headReserves => context.HeadReserve.ToArray();
        public IEnumerable<BoxesReserve> boxesReserves => context.BoxesReserve.ToArray();
        public IEnumerable<MarksReserve> marksReserves => context.MarksReserve.ToArray();

        public IEnumerable<Arrival> arrivals => context.Arrival.ToArray();
        public IEnumerable<Material> materials => context.Material.ToArray();
        public IEnumerable<Pallet> pallets => context.Pallet.ToArray();
        public IEnumerable<Carton> cartons => context.Carton.ToArray();
        public IEnumerable<Mark> marks => context.Mark.ToArray();

        public HeadReserve GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches, ReserveMarksRequest requestObject){

            HeadReserve selectedDoc = headReserves
                .Where(t => t.Location == location && t.Document == document && artikuls.Contains(t.Artikul) && batches.Contains(t.Batch)).FirstOrDefault();

            return selectedDoc;
        }

        public void AddMarks(Arrival arrival){
            context.Arrival.Add(arrival);
            context.SaveChanges();
        }
    }
}