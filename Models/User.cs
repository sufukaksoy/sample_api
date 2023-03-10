using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sample_api.Models
{
    
    public class User 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public DateTime createdAt { get; set; }
    }
}