using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Repository;

namespace StudentApp.Services;

    public class AuditLogService
    {
        public void Register()
        {
            Console.WriteLine("Enter Entity Name (e.g., Student, Course): ");
            string entityName = Console.ReadLine();

            Console.WriteLine("Enter Entity ID: ");
            int entityId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Action (e.g., INSERT, UPDATE, DELETE): ");
            string action = Console.ReadLine();

            Console.WriteLine("Enter Details: ");
            string details = Console.ReadLine();

            List<Auditlogs> logList = new List<Auditlogs>();
            logList.Add(new Auditlogs(0, entityName, entityId, action, details, DateTime.Now));

            AuditLogRepository obj = new AuditLogRepository();
            obj.AsyncAddAuditLog(logList);

            Console.WriteLine("Audit Log Recorded Successfully");
        }

        public void Display()
        {
            AuditLogRepository obj = new AuditLogRepository();
            List<Auditlogs> l = obj.GetAuditLogData();

            foreach (Auditlogs s in l)
            {
                Console.WriteLine($"Log ID: {s.AuditId} | Entity: {s.EntityName} (ID: {s.EntityId}) | Action: {s.Action} | Details: {s.Details} | Date: {s.CreatedAt}");
            }
        }

        public void Run()
        {
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("\n--- Audit Log Management ---");
                Console.WriteLine("1. Record Action (Manual Entry)");
                Console.WriteLine("2. View Recent Entries");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Display();
                        break;
                    case "0":
                        valid = false;
                        break;
                }
            }
        }
    }


