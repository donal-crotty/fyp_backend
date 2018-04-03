using Fyp_Backend.Models;
using System;
using System.Collections;

namespace Fyp_Backend
{
    public class TidalPredictionPersistance
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public TidalPredictionPersistance()
        {
            //connect to DB
            string myConnectionString;
            // string serverName = "http://192.168.1.39/phpmyadmin/";
            //myConnectionString = "server="+serverName+";uid=root;pwd=admin;database=tidal_wave_prediction_app";
            myConnectionString = "server=localhost;uid=root;pwd=admin;database=tidal_wave_prediction_app";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        public long saveTidalPrediction(TidalPrediction tidalPredictionToSave)
        {
            // var date = tidalPredictionToSave.Date.ToString("yyyy-MM-dd");
            //POST functionality
            String sqlString = "INSERT INTO tidalprediction (Latitude, Longitude, StationLocation, Date, Water_Level, Water_Level_ODM) " +
                "VALUES (" + tidalPredictionToSave.Longitude + "," + tidalPredictionToSave.Latitude + ",'" + tidalPredictionToSave.StationLocation
                + "','" + tidalPredictionToSave.Date + "'," + tidalPredictionToSave.Water_Level + "," + tidalPredictionToSave.Water_Level_ODM + ")";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long id = (int)cmd.LastInsertedId;

            return id;
        }
        public ArrayList getAllTidalPredictions()
        {
            //GET all Tidal Predictions
            ArrayList tidalPredictionArray = new ArrayList();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tidalprediction";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            while (mySqlReader.Read())
            {
                TidalPrediction tp = new TidalPrediction();
                tp.PredictionID = mySqlReader.GetInt32(0);
                tp.Latitude = mySqlReader.GetDouble(1);
                tp.Longitude = mySqlReader.GetDouble(2);
                tp.StationLocation = mySqlReader.GetString(3);
                tp.Date = mySqlReader.GetDateTime(4);
                tp.Water_Level = mySqlReader.GetDouble(5);
                tp.Water_Level_ODM = mySqlReader.GetDouble(6);
                tidalPredictionArray.Add(tp);
            }
            return tidalPredictionArray;
        }

        public TidalPrediction getTidalPredictionByID(int ID)
        {
            //GET Tidal Prediction by ID
            TidalPrediction tp = new TidalPrediction();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tidalprediction WHERE PredictionID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                tp.PredictionID = mySqlReader.GetInt32(0);
                tp.Latitude = mySqlReader.GetDouble(1);
                tp.Longitude = mySqlReader.GetDouble(2);
                tp.StationLocation = mySqlReader.GetString(3);
                tp.Date = mySqlReader.GetDateTime(4);
                tp.Water_Level = mySqlReader.GetDouble(5);
                tp.Water_Level_ODM = mySqlReader.GetDouble(6);
                return tp;
            }
            else
            {
                return null;
            }
        }

        public TidalPrediction getTidalPredictionByStation(string station)
        {
            //GET Tidal Prediction by StationLocation
            TidalPrediction tp = new TidalPrediction();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tidalprediction WHERE StationLocation = '" + station + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                tp.PredictionID = mySqlReader.GetInt32(0);
                tp.Latitude = mySqlReader.GetDouble(1);
                tp.Longitude = mySqlReader.GetDouble(2);
                tp.StationLocation = mySqlReader.GetString(3);
                tp.Date = mySqlReader.GetDateTime(4);
                tp.Water_Level = mySqlReader.GetDouble(5);
                tp.Water_Level_ODM = mySqlReader.GetDouble(6);
                return tp;
            }
            else
            {
                return null;
            }
        }


        public TidalPrediction getTidalPredictionByDate(DateTime date)
        {
            //GET Tidal Prediction by Date
            TidalPrediction tp = new TidalPrediction();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM tidalprediction WHERE Date = " + date;
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                tp.PredictionID = mySqlReader.GetInt32(0);
                tp.Latitude = mySqlReader.GetDouble(1);
                tp.Longitude = mySqlReader.GetDouble(2);
                tp.StationLocation = mySqlReader.GetString(3);
                tp.Date = mySqlReader.GetDateTime(4);
                tp.Water_Level = mySqlReader.GetDouble(5);
                tp.Water_Level_ODM = mySqlReader.GetDouble(6);
                return tp;
            }
            else
            {
                return null;
            }
        }
    }
}
