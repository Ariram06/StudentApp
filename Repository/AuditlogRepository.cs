using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Services;
using Microsoft.Data.SqlClient;

namespace StudentApp.Repository;
        public class AuditLogRepository
        {
            private readonly string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

            public void AsyncAddAuditLog(List<Auditlogs> l)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = "INSERT INTO AuditLogs (EntityName, EntityId, Action, Details, CreatedAt) VALUES (@EntityName, @EntityId, @Action, @Details, @CreatedAt);";

                foreach (Auditlogs x in l)
                {
                    using SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@EntityName", x.EntityName);
                    cmd.Parameters.AddWithValue("@EntityId", x.EntityId);
                    cmd.Parameters.AddWithValue("@Action", x.Action);
                    cmd.Parameters.AddWithValue("@Details", (object)x.Details ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", x.CreatedAt);

                    cmd.ExecuteNonQuery();
                }
            }

            public List<Auditlogs> GetAuditLogData()
            {
                List<Auditlogs> data = new List<Auditlogs>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = "SELECT AuditId, EntityName, EntityId, Action, Details, CreatedAt FROM AuditLogs ORDER BY CreatedAt DESC;";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long id = reader.GetInt64(0);
                    string entityName = reader.GetString(1);
                    int entityId = reader.GetInt32(2);
                    string action = reader.GetString(3);
                    string details = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    DateTime createdAt = reader.GetDateTime(5);

                    data.Add(new Auditlogs(id, entityName, entityId, action, details, createdAt));
                }

                return data;
            }
        }
    
