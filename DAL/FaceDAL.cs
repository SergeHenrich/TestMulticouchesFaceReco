using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DAL
{
    public class FaceDAL
    {
        FaceBLL fbll = new FaceBLL();
        private string connectionString;

        public FaceDAL(string dbPath)
        {
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Visual Studio 2015\Projects\TestMulticouchesFaceReco\DAL\FacialDdb.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public void SaveFaceData(byte[] faceData, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Face(nom, face) VALUES(@nom, @face)", connection);
                cmd.Parameters.AddWithValue("@nom", name);
                cmd.Parameters.AddWithValue("@face", faceData);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Tuple<string, Image<Gray, byte>>> LoadTrainingData()
        {
            List<Tuple<string, Image<Gray, byte>>> trainingData = new List<Tuple<string, Image<Gray, byte>>>();

            string query = "SELECT * FROM Face";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        
                        string name = rdr.GetString(1);
                        var imageBytes = (byte[])rdr[2];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            Image img = Image.FromStream(ms);
                            Bitmap bmp = new Bitmap(img);
                            trainingData.Add(new Tuple<string, Image<Gray, byte>>(name, new Image<Gray, byte>(bmp)));
                            
                        }
                    }
                }
            }

            return trainingData;
        }
    }
}
