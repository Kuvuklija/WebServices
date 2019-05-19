using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebServices.Models{

    public class HeadReserve{
        [JsonIgnore]
        public long Id { get; set; }
        public string Location { get; set; }
        public string Document { get; set; }
        public string Result { get; set; }
        public string Artikul { get; set; }
        public string Batch { get; set; }
        public string DocumentRow { get; set; }

        public virtual List<BoxesReserve> BoxesReserve { get; set; }
    }

    public class BoxesReserve {
        [JsonIgnore]
        public long Id { get; set; } 
        public string PalletBarcode { get; set; }
        public string CartonBarcode { get; set; }

        public long HeadReserveId { get; set; }
        public virtual List<MarksReserve> MarksReserve { get; set; }
    }

    public class MarksReserve {
        [JsonIgnore]
        public long Id { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public long BoxesReserveId { get; set; }
    }
}