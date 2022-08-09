using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrudSQLIte.Models
{
    public class CycleModel
    {
        [Key]
        public int Id { get; set; }
        public string Station { get; set; }
        public string veloManuelle { get; set; }
        public string veloElectriques { get; set; }
    }
}
