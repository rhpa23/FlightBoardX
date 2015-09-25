using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlightBoardX.Models;

namespace FlightBoardX.Database
{

    public class LocalDataBase
    {

        private string connString;

        public LocalDataBase()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //connString = @"Data Source=(LocalDB)\v11.0;Integrated Security=False;AttachDbFilename=" + path + "\\MySmallDatabase.mdf";
            connString = @"Data Source=" + path + "\\SmallDatabase.s3db";
        }

        #region Bases

        public void InsertBase(Base myBase)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    
                    var cmdSql = new SQLiteCommand("INSERT INTO [Bases] (icao) VALUES (@icao)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@icao", myBase.ICAO);
                    cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<Base> SelectAllBase()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [Bases]", conn);
                    conn.Open();
                    var reader = cmdSql.ExecuteReader();

                    var listAll = new List<Base>();
                    while (reader.Read())
                    {
                        var myBase = new Base();
                        myBase.ICAO = reader["icao"].ToString().Trim();
                        listAll.Add(myBase);
                    }
                    reader.Dispose();
                    conn.Close();
                    return listAll;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            return null;
        }

        public void DeleteBase(Base myBase)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("DELETE FROM [Bases] WHERE icao = (@icao)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@icao", myBase.ICAO);
                    int result = cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        #endregion


        #region Planes

        public void InsertPlane(Plane myPlane)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("INSERT INTO [MyPlanes] (Companny, Country, IdPlaneModel)  VALUES (@companny, @country, @idPlaneModel)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@companny", myPlane.Companny);
                    cmdSql.Parameters.AddWithValue("@country", myPlane.Country);
                    cmdSql.Parameters.AddWithValue("@idPlaneModel", myPlane.Model.id);
                    cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<Plane> SelectAllPlanes()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [MyPlanes]", conn);
                    conn.Open();
                    var reader = cmdSql.ExecuteReader();

                    var listAll = new List<Plane>();
                    while (reader.Read())
                    {
                        var plane = new Plane();
                        plane.Companny = reader["companny"].ToString().Trim();
                        plane.Country = reader["country"].ToString().Trim();
                        var idModel = reader["idPlaneModel"].ToString().Trim();
                        plane.Model = SelectModel(long.Parse(idModel));
                        listAll.Add(plane);
                    }

                    reader.Dispose();
                    conn.Close();
                    return listAll;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<Plane> SelectlPlanesByCountry(string country)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [MyPlanes] WHERE UPPER(country) = UPPER(@country)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@country", country);
                    var reader = cmdSql.ExecuteReader();

                    var listAll = new List<Plane>();
                    while (reader.Read())
                    {
                        var plane = new Plane();
                        plane.Companny = reader["companny"].ToString().Trim();
                        plane.Country = reader["country"].ToString().Trim();
                        var idModel = reader["idPlaneModel"].ToString().Trim();
                        plane.Model = SelectModel(long.Parse(idModel));
                        listAll.Add(plane);
                    }

                    reader.Dispose();
                    conn.Close();
                    return listAll;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void DeletePlane(Plane myPlane)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("DELETE FROM [MyPlanes] WHERE companny = (@companny) AND idPlaneModel = (@idPlaneModel)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@companny", myPlane.Companny);
                    cmdSql.Parameters.AddWithValue("@idPlaneModel", myPlane.Model.id);
                    int result = cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        #endregion


        #region PlaneModel

        public void InsertModel(PlaneModel myModel)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("INSERT INTO [PlaneModel] (Name, Cost, FuelConsumption)  VALUES (@name, @cost, @fuelConsumption)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@name", myModel.Name);
                    cmdSql.Parameters.AddWithValue("@cost", myModel.Cost);
                    cmdSql.Parameters.AddWithValue("@fuelConsumption", myModel.FuelConsumption);
                    cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<PlaneModel> SelectAllModels()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [PlaneModel]", conn);
                    conn.Open();
                    var reader = cmdSql.ExecuteReader();

                    var listAll = new List<PlaneModel>();
                    while (reader.Read())
                    {
                        var planeModel = new PlaneModel();
                        planeModel.id = Convert.ToInt64(reader["id"].ToString());
                        planeModel.Name = reader["name"].ToString().Trim();
                        planeModel.Cost = Convert.ToDecimal(reader["cost"].ToString().Trim());
                        planeModel.FuelConsumption = Convert.ToDecimal(reader["fuelConsumption"].ToString().Trim());
                        listAll.Add(planeModel);
                    }
                    reader.Dispose();
                    conn.Close();
                    return listAll;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public PlaneModel SelectModel(long id)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [PlaneModel] WHERE id = @id", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@id", id);
                    var reader = cmdSql.ExecuteReader();

                    var planeModel = new PlaneModel();
                    while (reader.Read())
                    {
                        planeModel.id = Convert.ToInt64(reader["id"].ToString());
                        planeModel.Name = reader["name"].ToString().Trim();
                        planeModel.Cost = Convert.ToDecimal(reader["cost"].ToString().Trim());
                        planeModel.FuelConsumption = Convert.ToDecimal(reader["fuelConsumption"].ToString().Trim());
                    }

                    reader.Dispose();
                    conn.Close();
                    return planeModel;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void DeleteModel(PlaneModel myModel)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("DELETE FROM [PlaneModel] WHERE name = (@name)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@name", myModel.Name);
                    int result = cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        #endregion


        #region Situation
        internal Situation SelectSituation()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("SELECT * FROM [Situation]", conn);
                    conn.Open();
                    var reader = cmdSql.ExecuteReader();

                    var situation = new Situation();
                    while (reader.Read())
                    {
                        situation.Id = Convert.ToInt64(reader["id"].ToString());
                        situation.CurrentLocation = reader["CurrentLocationICAO"].ToString().Trim();
                        situation.CompanyCash = Convert.ToDecimal(reader["CompanyCash"].ToString().Trim());
                        break;
                    }
                    reader.Dispose();
                    conn.Close();
                    return situation;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        internal void InsertSituation(Situation situation)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {

                    var cmdSql = new SQLiteCommand("INSERT INTO [Situation] (CurrentLocationICAO, CompanyCash)  VALUES (@currentLocationICAO, @companyCash)", conn);
                    conn.Open();
                    cmdSql.Parameters.AddWithValue("@currentLocationICAO", situation.CurrentLocation);
                    cmdSql.Parameters.AddWithValue("@companyCash", situation.CompanyCash);
                    cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        internal void UpdateSituation(Situation situation)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    var cmdSql = new SQLiteCommand("Update Situation SET CurrentLocationICAO = @currentLocationICAO, CompanyCash = @companyCash WHERE id = @id", conn);
                    cmdSql.Parameters.AddWithValue("@currentLocationICAO", situation.CurrentLocation);
                    cmdSql.Parameters.AddWithValue("@companyCash", situation.CompanyCash);
                    cmdSql.Parameters.AddWithValue("@id", situation.Id);
                    int result = cmdSql.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        #endregion
    }
}
