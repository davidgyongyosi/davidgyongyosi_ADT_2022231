using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace davidgyongyosi_ADT_2022231.Models
{
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(240)]
        public string PlatformName { get; set; }

        //Navigation Property
        [JsonIgnore]
        public virtual ICollection<Game> Games { get; set; }

        public Platform()
        {
            this.Games = new HashSet<Game>();
        }

        public Platform(int id, string platformName)
        {
            Id = id;
            PlatformName = platformName;
        }
    }
}

