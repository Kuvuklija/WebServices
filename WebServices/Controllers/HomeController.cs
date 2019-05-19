using System.Web.Mvc;

namespace WebServices.Controllers{

    public class HomeController : Controller{

        //  ---MVC---
        //private ReservationRepository repo = ReservationRepository.Current;
    
        //public ActionResult Index(){
        //    return View(repo.GetAll());
        //}

        //public ActionResult Add(Reservation item) {
        //    if (ModelState.IsValid) {
        //        repo.Add(item);
        //        return RedirectToAction("Index");
        //    } else {
        //        return View("Index");
        //    }
        //}

        //public ActionResult Remove(int id) {
        //    repo.Remove(id);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Update(Reservation item) {
        //    if(ModelState.IsValid && repo.Update(item)) {
        //        return RedirectToAction("Index");
        //    } else {
        //        return View("Index");
        //    }
        //}

        public ViewResult Index() {
            return View(); //only html-markup, model is used by API controller
        }
    }
}