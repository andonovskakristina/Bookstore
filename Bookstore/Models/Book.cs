using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bookstore.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}