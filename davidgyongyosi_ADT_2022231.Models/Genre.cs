using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace davidgyongyosi_ADT_2022231.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string GenreName { get; set; }

        //Navigation property
        [JsonIgnore]
        public virtual ICollection<Game> Games { get; set; }

        public Genre()
        {
            Games = new HashSet<Game>();
        }

        public Genre(int id, string genreName)
        {
            Id = id;
            GenreName = genreName;
        }
    }
}

