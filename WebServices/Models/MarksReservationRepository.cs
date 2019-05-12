using System.Collections.Generic;
using System.Linq;
using WebServices.Controllers;

namespace WebServices.Models
{
    internal class MarksReservationRepository
    {
        private static MarksReservationRepository repo = new MarksReservationRepository();

        public static MarksReservationRepository CurrentRepository { get { return repo; } }

        //private List<ReserveMarksResponse> context = new List<ReserveMarksResponse> {
        //    new ReserveMarksResponse {Location="Москва, Россия", Document="190321-РАШР0003555", Artikul="49.097.01.08.16",
        //        Batch ="000227599",DocumentRow="1" },
        //    new ReserveMarksResponse {Location="Москва, Россия", Document="190321-РАШР0003555", Artikul="96.551.01.07.49",
        //        Batch ="000213884",DocumentRow="2"},
        //    new ReserveMarksResponse {Location="Москва, Россия", Document="190321-РАШР0003555", Artikul="49.097.01.08.16",
        //        Batch ="000221233",DocumentRow="3"},
        //    new ReserveMarksResponse {Location="Москва, Россия", Document="190321-РАШР0003555", Artikul="49.097.01.08.16",
        //        Batch ="000227555",DocumentRow="4" },
        //    new ReserveMarksResponse {Location="Москва, Россия", Document="190321-РАШР0003555", Artikul="49.097.01.08.16",
        //        Batch ="000227556",DocumentRow="5"}
        //};

        //public IEnumerable<ReserveMarksResponse> GetAll()
        //{
        //    return context;
        //}

        //public IEnumerable<ReserveMarksResponse> Get(string location, string document, IEnumerable<string> id, IEnumerable<string> batch)
        //{
        //    return context
        //        .Where(x => x.Location == location && x.Document == document && x.Batch.Any(t => batch.Contains(t.ToString())));
        //}
    }
}