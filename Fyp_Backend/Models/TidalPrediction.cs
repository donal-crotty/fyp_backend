using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fyp_Backend.Models
{
    public class TidalPrediction
    {
        public int PredictionID { get; set; }

        public string Time { get; set; }

        public string StationLocation { get; set; }

        public Double Longitude { get; set; }

        public Double Latitude { get; set; }

        public Double Water_Level { get; set; }

        public Double Water_Level_ODM { get; set; }

    }
}
