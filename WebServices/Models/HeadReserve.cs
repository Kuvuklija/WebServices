using System.Collections.Generic;

namespace WebServices.Models
{
    public class HeadReserve{
        public long Id { get; set; }
        public string Location { get; set; }
        public string Document { get; set; }
        public string Result { get; set; }
        public string Artikul { get; set; }
        public string Batch { get; set; }
        public string DocumentRow { get; set; }

        public virtual ICollection<BoxesReserve> BoxesReserve { get; set; }
    }

    public class BoxesReserve {
        public long Id { get; set; } 
        public string PalletBarcode { get; set; }
        public string CartonBarcode { get; set; }

        public long HeadReserveId { get; set; }
        public virtual HeadReserve HeadReserve { get; set; }

        public virtual ICollection<MarksReserve> MarksReserve { get; set; }
    }

    public class MarksReserve {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public long BoxesReserveId { get; set; }
        public virtual BoxesReserve BoxesReserve { get; set; }
    }
}