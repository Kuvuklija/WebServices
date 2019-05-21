using System.Collections.Generic;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices{

    public interface IRepository{

        IEnumerable<Arrival> arrivals { get; }
        IEnumerable<Material> materials { get; }
        IEnumerable<Pallet> pallets { get; }
        IEnumerable<Carton> cartons { get; }
        IEnumerable<Mark> marks { get; }

        void AddMarks(Arrival arrival);

        Arrival GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches, ReserveMarksRequest request);
    }
}
