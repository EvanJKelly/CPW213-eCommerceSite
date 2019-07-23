using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class VideoGame
    {
        /// <summary>
        /// Unique ID number for the game
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The game Title
        /// </summary>
        [Required]
        [StringLength(90)]
        public string Title { get; set; }

        /// <summary>
        /// Offical ESRB Rating
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// The game descripton
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Retail price for the game 
        /// </summary>
        [Range(0.01, 999.99)]
        [DataType(DataType.Currency)]
        //Required by default because double is a value type
        public double Price { get; set;  }

    }
}
