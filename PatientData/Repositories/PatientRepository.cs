using Microsoft.Extensions.Configuration;
using PatientDomain.Entities;
using PatientDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientData.Repositories
{
    public class PatientRepository : IGenericRepository<Patient>
    {
        private readonly IConfiguration configuration;

        public PatientRepository( IConfiguration Configuration) {
            configuration = Configuration;
        }
        private string? GetConnectionString()
        {
            var _conn = configuration.GetConnectionString("DefaultConnection");
            return _conn;
        }

        public async Task<Patient> Add(Patient entity)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Patients (name, age, phonenumber, email, gender) VALUES (@Name,@Age, @PhoneNumber, @Email, @Gender)";
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Age", entity.Age);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                    cmd.Parameters.AddWithValue("@Created", entity.Created);
                    cmd.Parameters.AddWithValue("@LastModified", entity.LastModified);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return entity;
                }
            }
        }

        public async Task<List<Patient>> GetAll()
        {
            List<Patient> patient = new();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    
                    cmd.CommandText = "SELECT * FROM Patients";
                    con.Open();

                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        patient.Add(new Patient()
                        {
                            Id = Convert.ToInt32(rdr["id"]),
                            Name = rdr["Name"].ToString(),
                            Age = (int) rdr["Age"],
                            PhoneNumber = rdr["PhoneNumber"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Gender = rdr["Name"].ToString()
                        });
                    }
                    con.Close();
                }
            }

            return patient;
        }

        public Task<List<Patient>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetQueryEntity()
        {
            throw new NotImplementedException();
        }

        public async Task<Patient> Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM Patients WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return new Patient();
                }
            }
        }

        public async Task<Patient> Update(Patient entity)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Patients SET NAME = @Name,Age = @Age, PhoneNumber = @PhoneNumber," +
                       "Email = @Email, Gender = @Gender  WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Age", entity.Age);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Gender", entity.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return entity;
        }

        public Task<Patient> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
