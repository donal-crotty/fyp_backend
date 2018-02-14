using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fyp_Backend.Models;
using System.Collections;

namespace Fyp_Backend.Controllers
{
    [Route("api/[controller]")]
    public class TidalPredictionController : Controller
    {
        // GET api/values
        [HttpGet]
        public ArrayList Get()
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            return tpp.getAllTidalPredictions();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TidalPrediction Get(int id)
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            TidalPrediction tidalPrediction = tpp.getTidalPrediction(id);

            //pred.PredictionID = id;
            //pred.Time = DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");
            //pred.StationLocation = "Arklow";
            //pred.Latitude = 34.9896;
            //pred.Longitude = -14.49562;
            //pred.Water_Level = 2.1;
            //pred.Water_Level = -1.53;

            return tidalPrediction;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TidalPrediction value)
        {
            TidalPredictionPersistance tpp = new TidalPredictionPersistance();
            int id;
            id = (int)tpp.saveTidalPrediction(value);

            value.PredictionID = id;
            //RETURN HTTP STATUS CODES

            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("TidalPrediction/{0}", id));
            //return response;


        }

        // PUT api/values/5
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
