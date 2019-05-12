using System.Collections.Generic;

namespace WebServices.Controllers{

    public class ReserveMarksRequest{

        public string Location { get; set; }
        public string Document { get; set; }
        public string Result { get; set; }
        public IEnumerable<ReserveMarksRequestMaterial> Materials { get; set; }
        public string Status { get; set; }
    }

    public class ReserveMarksRequestMaterial {
        public string Artikul{ get; set; }
        public string Batch { get; set; }
    }
}