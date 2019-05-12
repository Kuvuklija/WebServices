using System.Collections.Generic;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices{

    public interface IRepository{

        IEnumerable<HeadReserve> headReserves { get; }
        IEnumerable<BoxesReserve> boxesReserves { get; }
        IEnumerable<MarksReserve> marksReserves { get; }

        void AddMarks(HeadReserve headReserve, BoxesReserve boxesReserve, MarksReserve marksReserve);

        string GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches);
    }
}
