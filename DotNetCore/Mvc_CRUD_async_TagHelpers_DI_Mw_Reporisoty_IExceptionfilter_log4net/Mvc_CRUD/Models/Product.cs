using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace Mvc_CRUD.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Range(1, 10000)]
        public int Price { get; set; }
    }
}
