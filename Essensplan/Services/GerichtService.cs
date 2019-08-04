using Essensplan.Models.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Essensplan.Services
{
    public class GerichtService
    {
        private string ConnectionString { get; set; }

        public GerichtService()
        {
            if (Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process) != null)
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);

            if (Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User) != null)
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);

            if (Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Machine) != null)
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Machine);

            if (ConnectionString == null)
                ConnectionString = "Essensplan.db";
        }

        public Gericht Create(Gericht gericht)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                collection.IncludeAll().Insert(gericht);
                return gericht;
            }
        }

        public List<Gericht> All()
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                return collection.IncludeAll().FindAll().ToList();
            }
        }

        public Gericht Single(Guid guid)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                return collection.IncludeAll().FindOne(c => c.Guid == guid);
            }
        }

        public Gericht Random()
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                var all = collection.IncludeAll().FindAll().ToList();
                return all.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
            }
        }

        public Gericht Update(Gericht gericht)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                collection.IncludeAll().Update(gericht);
                return gericht;
            }
        }
        
        public bool Delete(Guid guid)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Gericht>("gerichte");
                return collection.IncludeAll().Delete(c => c.Guid == guid) > 0;
            }
        }        
    }
}
