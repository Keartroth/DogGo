using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public class WalkRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walk> GetAllWalkersWalks(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                               w.Id AS walkId, 
                               w.Date, 
                               w.Duration, 
                               w.WalkerId,
                               w.DogId,
                               d.Id as dogId,
                               D.OwnerId
                          FROM Walks w
                          JOIN Dog d ON d.Id = w.DogId
                         WHERE WalkerId = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walk> walks = new List<Walk>();
                    while (reader.Read())
                    {
                        Walk walk = new Walk
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("walkId")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            Dog = new Dog
                            {
                                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId"))
                            }
                        };

                        walks.Add(walk);
                    }

                    reader.Close();

                    return walks;
                }
            }
        }
    }
}