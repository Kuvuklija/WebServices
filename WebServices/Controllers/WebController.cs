﻿using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers{

    public class WebController : ApiController{

        private ReservationRepository repo = ReservationRepository.Current;
        
        //RESTfull

        //URL methods
        public IEnumerable<Reservation> GetAllReservations() {
            return repo.GetAll();
        }

        public Reservation GetReservation(int id) {
            return repo.Get(id);
        }

        //HTTP methods
        [HttpPost]
        public Reservation CreateReservation(Reservation item) {
            return repo.Add(item);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation item) {
            return repo.Update(item);
        }

        public void DeleteReservation(int id) {
            repo.Remove(id);
        }
    }
}
