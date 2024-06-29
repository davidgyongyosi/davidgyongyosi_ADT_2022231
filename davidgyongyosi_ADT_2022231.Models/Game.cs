using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace davidgyongyosi_ADT_2022231.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string releaseDate { get; set; }

        [Required]
        public double Price { get; set; }

        //Foreign Keys
        public int GenreId { get; set; }

        //Navigation properties
        public virtual Genre Genre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Platform> Platforms { get; set; }

        public Game()
        {
            this.Platforms = new HashSet<Platform>();
        }

        public Game(int id, string gameName, string releaseDate, double price, int genreId)
        {
            Id = id;
            GameName = gameName;
            this.releaseDate = releaseDate;
            Price = price;
            GenreId = genreId;
        }
    }
}

