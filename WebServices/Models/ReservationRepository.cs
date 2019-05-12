﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Concrete;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace WebServices.Models
{
    public class ReservationRepository:IRepository{

        private EFContext context=new EFContext();

        public IEnumerable<HeadReserve> headReserves=>context.HeadReserve;
        public IEnumerable<BoxesReserve> boxesReserves=>context.BoxesReserve;
        public IEnumerable<MarksReserve> marksReserves=>context.MarksReserve;

        public string GetMarks(string location, string document, IEnumerable<string> artikuls, IEnumerable<string> batches){

            var selectedHeads = from t in headReserves 
                               where t.Location==location && t.Document==document && artikuls.Contains(t.Artikul) && batches.Contains(t.Batch)
                               group t by t.DocumentRow into g
                               select g; 

            JavaScriptSerializer ser = new JavaScriptSerializer();

            string header="";
            string boxes="";
            string marks="";
            string singleObject = "";
            foreach (var s in selectedHeads){ //very bad!!!!!!!!!!!
                    //header
                    Func<HeadReserve, JObject> objToJson1 =
                        o => new JObject(
                            new JProperty("Location", o.Location),
                            new JProperty("Document", o.Document),
                            new JProperty("Result", "Ok"),
                            new JProperty("Artikul", o.Artikul),
                            new JProperty("Batch", o.Batch),
                            new JProperty("DocumentRow", o.DocumentRow));
                    header += new JArray(s.Select(objToJson1)).ToString();
                    //boxes
                    foreach (HeadReserve hr in s){
                        List<BoxesReserve> boxCollection = hr.BoxesReserve.ToList();
                        Func<BoxesReserve, JObject> objToJson2 =
                        o => new JObject(
                            new JProperty("PalletBarcode", o.PalletBarcode),
                            new JProperty("CartonBarcode", o.CartonBarcode));
                        boxes += new JArray(boxCollection.Select(objToJson2)).ToString();
                        //marks
                        foreach (BoxesReserve br in boxCollection){
                            List<MarksReserve> markCollection = br.MarksReserve.ToList(); //with IEnumerable
                            Func<MarksReserve, JObject> objToJson3 =
                                o => new JObject(
                                    new JProperty("Code", o.Code),
                                    new JProperty("Status", o.Status));
                            marks += new JArray(markCollection.Select(objToJson3)).ToString();
                        }
                    boxes += marks;
                    }
                    singleObject += header + boxes + marks;
                }
            return singleObject;
        }

        private static ReservationRepository repo = new ReservationRepository();

        public static ReservationRepository Current{get{return repo;}}

        private List<Reservation> data = new List<Reservation> {
            new Reservation { ReservationId = 1, ClientName = "Adam", Location = "Board Room"},
            new Reservation {ReservationId = 2, ClientName = "Jacqui", Location = "Lecture Hall"},
            new Reservation {ReservationId = 3, ClientName = "Russell", Location = "Meeting Room 1"},
        };

        //CRUD
        public IEnumerable<Reservation> GetAll(){
            return data;
        }

        public Reservation Get(int id){
            return data.Where(r => r.ReservationId == id).FirstOrDefault();
        }

        public void AddMarks(HeadReserve headReserve, BoxesReserve boxesReserve, MarksReserve marksReserve ){
           //TODO
        }

        public Reservation Add(Reservation item){
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id){
            Reservation item = Get(id);
            if (item != null){
                data.Remove(item);
            }
        }

        public bool Update(Reservation item){
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null){ //TODO
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            } else{
                return false;
            }
        }
    }
}
