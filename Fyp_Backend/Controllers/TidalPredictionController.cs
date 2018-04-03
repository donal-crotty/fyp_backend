using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fyp_Backend.Models;
using System.Collections;

namespace Fyp_Backend.Controllers
{
    [Route("api/tidalprediction")]
    public class TidalPredictionController : Controller
    {
        // GET api/tidalprediction
        [HttpGet]
        public ArrayList Get()
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            return tpp.getAllTidalPredictions();
        }

        // GET api/tidalprediction/1
        [HttpGet("{id}")]
        public TidalPrediction Get(int id)
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            TidalPrediction tidalPrediction = tpp.getTidalPredictionByID(id);


            return tidalPrediction;
        }
        // GET api/tidalprediction/StationLocation
        [HttpGet("{station}")]
        public TidalPrediction Get(string station)
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            TidalPrediction tidalPrediction = tpp.getTidalPredictionByStation(station);


            return tidalPrediction;
        }
        // POST api/tidalprediction
        [HttpPost]
        public void Post([FromBody]TidalPrediction value)
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            int id;
            id = (int)tpp.saveTidalPrediction(value);

            value.PredictionID = id;
            //RETURN HTTP STATUS CODES

            //    //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //    //response.Headers.Location = new Uri(Request.RequestUri, String.Format("TidalPrediction/{0}", id));
            //    //return response;


        }

        // PUT api/tidalprediction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
