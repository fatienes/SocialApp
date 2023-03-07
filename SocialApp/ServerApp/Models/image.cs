using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Image
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfile { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}