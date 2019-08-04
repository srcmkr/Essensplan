using Essensplan.Models.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Essensplan.Services
{
    public class TagService
    {
        private string ConnectionString { get; set; }

        public TagService()
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

        public Tag Create(Tag tag)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Tag>("tags");
                collection.IncludeAll().Insert(tag);
                return tag;
            }
        }

        public List<Tag> All()
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Tag>("tags");
                return collection.IncludeAll().FindAll().ToList();
            }
        }

        public Tag Single(Guid guid)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Tag>("tags");
                return collection.IncludeAll().FindOne(c => c.Guid == guid);
            }
        }

        public Tag Update(Tag tag)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Tag>("tags");
                collection.IncludeAll().Update(tag);
                return tag;
            }
        }
        
        public bool Delete(Guid guid)
        {
            using (var db = new LiteDatabase(ConnectionString))
            {
                var collection = db.GetCollection<Tag>("gerichte");
                return collection.IncludeAll().Delete(c => c.Guid == guid) > 0;
            }
        }        
    }
}
