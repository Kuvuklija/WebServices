
namespace WebServices.Concrete{

    public class ReserveInicial: System.Data.Entity. DropCreateDatabaseIfModelChanges<EFContext>{

       
            protected override void Seed(EFContext context){

                //var head = new List<HeadReserve>{
                //        new HeadReserve{Location="1",Document="111-111",Artikul="11111", Batch="11111", DocumentRow="1"},
                //        new HeadReserve{Location="1",Document="111-111",Artikul="22222", Batch="22222", DocumentRow="2"},
                //};

                //head.ForEach(s => context.HeadReserve.Add(s));
                //context.SaveChanges();

                //var boxes = new List<BoxesReserve>{
                //        new BoxesReserve{Id=1050,PalletBarcode="1111",CartonBarcode="0001",},
                //        new BoxesReserve{Id=4041,PalletBarcode="1111",CartonBarcode="0002",},
                //        new BoxesReserve{Id=1045,PalletBarcode="1111",CartonBarcode="0002",},
                //        new BoxesReserve{Id=3141,PalletBarcode="2222",CartonBarcode="0003",},
                //        new BoxesReserve{Id=2021,PalletBarcode="2222",CartonBarcode="0003",},
                //        new BoxesReserve{Id=2042,PalletBarcode="2222",CartonBarcode="0003",}
                //};
                //boxes.ForEach(s => context.BoxesReserve.Add(s));
                //context.SaveChanges();

                //var marks = new List<MarksReserve>{
                //            new MarksReserve{Id=1051,Code="11111111",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="22222222",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="33333333",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="44444444",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="55555555",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="66666666",Status="Reserve"},
                //            new MarksReserve{Id=1051,Code="77777777",Status="Stock"},
                //    };
                //marks.ForEach(s => context.MarksReserve.Add(s));
                //context.SaveChanges();
        }
    }
}