using LiteDB;
using System;
using System.ComponentModel.DataAnnotations;

namespace Essensplan.Models.Models
{
    public class Tag
    {
        [BsonId]
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
