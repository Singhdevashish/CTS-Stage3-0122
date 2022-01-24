using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EfCoreCodeFirst
{
    public class Department
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(30)")]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
