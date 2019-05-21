using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models{

    public class Arrival {
        [JsonIgnore]
        public long Id { get; set; }
        public string Location { get; set; }
        public string Document { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Material> Materials { get; set; }
    }

    public class Material {
        [JsonIgnore]
        public long Id { get; set; }
        public string Artikul { get; set; }
        public string Batch { get; set; }
        public string RegForm1 { get; set; }
        public string RegForm2 { get; set; }
        public string AlcoCode { get; set; }
        public string DocumentRow { get; set; }
        public virtual List<Pallet> Pallets{get;set;}
        public long ArrivalId { get; set; }
    }

    public class Pallet {
        [JsonIgnore]
        public long Id { get; set; }
        public bool VirtualPallete { get; set; }
        public string PalletCode { get; set; }
        public virtual List<Carton> Cartons { get; set; }
        public long MaterialId { get; set; }
    }

    public class Carton {
        [JsonIgnore]
        public long Id { get; set; }
        public bool VirtualCarton { get; set; }
        public string CartonCode { get; set; }
        public virtual List<Mark> Marks { get; set; }
        public long PalletId { get; set; }
    }

    public class Mark {
        [JsonIgnore]
        public long Id { get; set; }
        public string MarkCode { get; set; }
        public long CartonId { get; set; }
    }
}