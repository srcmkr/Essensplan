using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Essensplan.Models.Models
{
    public class Gericht
    {
        [BsonId]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [BsonRef("tags")]
        public List<Tag> Tags { get; set; }
    }
}
